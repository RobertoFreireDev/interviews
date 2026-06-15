namespace order.tests.concurrency;

public class OrderControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly WebApplicationFactory<Program> _factory;
    private readonly int ProductId = 1;

    public OrderControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<OrderDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<OrderDbContext>(options =>
                {
                    options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = order; Integrated Security = True; Connect Timeout = 30; Encrypt=True;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False;Command Timeout = 30");
                });
            });
        });
        _client = _factory.CreateClient();
    }

    private OrderDbContext GetDbContext()
    {
        var scope = _factory.Services.CreateScope();
        return scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    }

    private async Task CleanupDatabaseAsync()
    {
        using var db = GetDbContext();
        await db.OrderItems.ExecuteDeleteAsync();
        await db.Orders.ExecuteDeleteAsync();
        await db.Inventories.ExecuteDeleteAsync();
    }

    private async Task InsertSeedDataAsync()
    {
        using var db = GetDbContext();
        var seeds = new List<InventoryEntity>
        {
            new() { Id = 1, ProductId = ProductId, Availability = 50 }
        };

        await db.Inventories.AddRangeAsync(seeds);
        await db.SaveChangesAsync();
    }

    private async Task<int> GetInventoryAvailabilityAsync()
    {
        using var db = GetDbContext();
        return await db.Inventories
            .AsNoTracking()
            .Where(i => i.ProductId == ProductId)
            .Select(i => i.Availability)
            .FirstOrDefaultAsync();
    }

    [Fact]
    public async Task CreateOrderAsync_ConcurrentRequests_ShouldHandleRaceConditions()
    {
        // Arrange
        await CleanupDatabaseAsync();
        await InsertSeedDataAsync();
        var initialAvailability = await GetInventoryAvailabilityAsync();

        var requestData = new CreateOrderRequest
        {
            Order = new CreateOrderDto
            {
                Items = new List<CreateOrderItemDto>()
                {
                    new CreateOrderItemDto()
                    {
                        ProductId = ProductId,
                        Price = 120000,
                        Quantity = 1,
                    }
                },
                TotalPrice = 120000
            }
        };

        int concurrentCount = 60;
        var tasks = new Task<HttpResponseMessage>[concurrentCount];

        // Act
        for (int i = 0; i < concurrentCount; i++)
        {
            tasks[i] = _client.PostAsJsonAsync("/Order", requestData);
        }

        HttpResponseMessage[] responses = await Task.WhenAll(tasks);

        // Assert
        int successCount = 0;
        int failureCount = 0;

        foreach (var response in responses)
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                successCount++;
                var content = await response.Content.ReadFromJsonAsync<CreateOrderResponse>();
                Assert.NotNull(content);
                Assert.True(content.Success);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                failureCount++;
            }
        }

        var finalAvailability = await GetInventoryAvailabilityAsync();

        Assert.Equal(successCount, initialAvailability - finalAvailability);
    }
}
