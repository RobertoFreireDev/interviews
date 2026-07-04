namespace Application;

public static class ProductMapper
{
    public static ProductResponse ToResponse(Product product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price
    };

    public static IEnumerable<ProductResponse> ToResponseList(IEnumerable<Product> products) =>
        products.Select(ToResponse);
}
