using Gateway.Extensions;
using System.Net;

namespace Gateway.Clients
{
    public class OrderClient : IOrderClient
    {
        private readonly HttpClient _httpClient;

        public OrderClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpContext context)
        {
            if (_httpClient.BaseAddress is null) throw new ArgumentNullException("No BaseAddress");

            var uri = new Uri(_httpClient.BaseAddress.ToString() + context.Request.Path.ToString().Remove(0,1));

            try
            {
                var result = await _httpClient.SendAsync(
                    context.CreateProxyHttpRequest(uri),
                    HttpCompletionOption.ResponseHeadersRead,
                    context.RequestAborted);

                return result;
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }            
        }
    }
}
