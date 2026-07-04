namespace Application.Interfaces;

public interface IProductRepository
{
    Task<(IEnumerable<Product> Items, int TotalCount)> GetProductsAsync(string searchTerm, int page, int pageSize);
}
