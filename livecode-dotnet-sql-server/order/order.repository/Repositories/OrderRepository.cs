namespace order.application.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _db;

    public OrderRepository(OrderDbContext db)
    {
        _db = db;
    }

    public async Task<bool> CreateOrderAsync(Order order)
    {
        // Validate customer exists
        // Validate TotalPrice
        // Validate products exist
        // Validate products prices
        // Validate stock availability using locking in multiple rows
        // Update database. Must be transactional
        // -------- Create order
        // -------- Create order items
        // -------- Decrease stock
        using var transaction = await _db.Database.BeginTransactionAsync();

        try
        {
            var customerExists = await _db.Customers.AnyAsync(c => c.Id == order.Customer.Id);
            if (!customerExists)
            {
                throw new InvalidOperationException($"Client {order.Customer.Id} doesn't exist");
            }

            var productIds = order.Items
                .Select(i => i.Product.Id)
                .Distinct()
                .OrderBy(id => id)
                .ToList();

            var idList = string.Join(",", productIds);
            var inventories = await _db.Inventories
                .FromSqlRaw($"SELECT * FROM Inventory WITH (XLOCK, ROWLOCK) WHERE ProductId IN ({idList})")
                .Include(i => i.Product)
                .ToDictionaryAsync(i => i.ProductId);

            int calculatedTotal = 0;

            foreach (var item in order.Items)
            {
                if (!inventories.TryGetValue(item.Product.Id, out var dbInventory))
                {
                    throw new InvalidOperationException($"Product with ID {item.Product.Id} doesn't exist in inventory");
                }

                var dbProduct = dbInventory.Product;

                if (dbProduct.Price != item.Price)
                {
                    throw new InvalidOperationException($"Product price {dbProduct.Name} changed");
                }

                if (dbInventory.Availability < item.Quantity)
                {
                    throw new InvalidOperationException($"Product {dbProduct.Name} unavailable.");
                }

                calculatedTotal += item.Price * item.Quantity;

                dbInventory.Availability -= item.Quantity;
            }

            if (order.TotalPrice != calculatedTotal)
            {
                throw new InvalidOperationException("Total Price doesn't match calculated total prices.");
            }

            var newOrder = new OrderEntity
            {
                CustomerId = order.Customer.Id,
                TotalPrice = order.TotalPrice,
                Items = order.Items.Select(i => new OrderItemEntity
                {
                    ProductId = i.Product.Id,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            await _db.Orders.AddAsync(newOrder);

            await _db.SaveChangesAsync();

            await transaction.CommitAsync();

            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
