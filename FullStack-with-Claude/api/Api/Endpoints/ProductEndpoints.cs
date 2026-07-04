namespace Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/Products/{searchterm}", async (
            string searchterm,
            [AsParameters] PaginationParameters pagingParams,
            IProductService productService) =>
        {
            var request = new GetProductsRequest
            {
                SearchTerm = searchterm,
                Page = pagingParams.Page,
                PageSize = pagingParams.PageSize
            };

            var result = await productService.GetProductsAsync(request);
            return Results.Ok(result);
        });

        return app;
    }
}
