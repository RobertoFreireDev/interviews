using LogLibrary.Constants;
using Microsoft.Extensions.Primitives;
using OrderApi.Dtos;
using System.Text.Json;

namespace OrderApi.Clients
{
    public class CatalogClient : ICatalogClient
    {
        private readonly HttpClient _httpClient;

        public CatalogClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> GetAsync(CancellationToken token, StringValues header)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/Catalog"))
            {
                requestMessage.Headers.Add(LogConstant.TraceIdHeader, header.ToString());

                using (var response = await _httpClient.SendAsync(requestMessage, token))
                {
                    var responseAsString = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    return JsonSerializer.Deserialize<ProductDto>(responseAsString, options);
                }
            }
        }
    }
}
