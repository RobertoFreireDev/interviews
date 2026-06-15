using Microsoft.Extensions.Primitives;
using OrderApi.Dtos;

namespace OrderApi.Clients
{
    public interface ICatalogClient
    {
        Task<ProductDto> GetAsync(CancellationToken token, StringValues header);
    }
}
