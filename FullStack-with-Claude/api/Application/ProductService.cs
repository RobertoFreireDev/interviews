namespace Application;

public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<PagedResponse<ProductResponse>> GetProductsAsync(GetProductsRequest request)
    {
        var (items, totalCount) = await repository.GetProductsAsync(
            request.SearchTerm, request.Page, request.PageSize);

        return new PagedResponse<ProductResponse>
        {
            Items = ProductMapper.ToResponseList(items),
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
