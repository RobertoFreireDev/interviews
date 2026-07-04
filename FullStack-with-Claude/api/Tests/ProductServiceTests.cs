namespace Tests;

public class ProductServiceTests
{
    private readonly IProductRepository _repository = Substitute.For<IProductRepository>();
    private readonly ProductService _sut;

    public ProductServiceTests()
    {
        _sut = new ProductService(_repository);
    }

    [Fact]
    public async Task GetProductsAsync_ReturnsPagedResponse_WhenProductsExist()
    {
        var products = new List<Product>
        {
            new() { Id = 1, Name = "Widget", Description = "A widget", Price = 999 },
            new() { Id = 2, Name = "Gadget", Description = "A gadget", Price = 1999 }
        };

        _repository.GetProductsAsync("widget", 1, 10)
            .Returns((products.AsEnumerable(), 2));

        var request = new GetProductsRequest { SearchTerm = "widget", Page = 1, PageSize = 10 };

        var result = await _sut.GetProductsAsync(request);

        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(1, result.Page);
        Assert.Equal(10, result.PageSize);
        Assert.Equal(2, result.Items.Count());
    }

    [Fact]
    public async Task GetProductsAsync_ReturnsEmptyPagedResponse_WhenNoProductsFound()
    {
        _repository.GetProductsAsync("nonexistent", 1, 10)
            .Returns((Enumerable.Empty<Product>(), 0));

        var request = new GetProductsRequest { SearchTerm = "nonexistent", Page = 1, PageSize = 10 };

        var result = await _sut.GetProductsAsync(request);

        Assert.NotNull(result);
        Assert.Equal(0, result.TotalCount);
        Assert.Empty(result.Items);
    }
}
