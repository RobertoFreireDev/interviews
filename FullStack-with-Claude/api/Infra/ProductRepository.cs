namespace Infra;

public class ProductRepository(ProductInventoryDbContext context) : IProductRepository
{
    public async Task<(IEnumerable<Product> Items, int TotalCount)> GetProductsAsync(
        string searchTerm, int page, int pageSize)
    {
        var query = context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(p =>
                p.Name.Contains(searchTerm) ||
                p.Description.Contains(searchTerm));

        var totalCount = await query.CountAsync();

        var entities = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var products = entities.Select(e => new Product
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            Price = e.Price
        });

        return (products, totalCount);
    }
}
