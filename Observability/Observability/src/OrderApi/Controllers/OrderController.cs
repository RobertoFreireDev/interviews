using LogLibrary.Constants;
using LogLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Clients;
using OrderApi.Dtos;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ICatalogClient _catalogClient;

        private ILogRequestService _logRequestService;

        public OrderController(
            ICatalogClient catalogClient,
            ILogRequestService logRequestService)
        {
            _catalogClient = catalogClient;
            _logRequestService = logRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken token)
        {
            try
            {
                Request.Headers.TryGetValue(LogConstant.TraceIdHeader, out var traceIdHeader);

                var product = await _catalogClient.GetAsync(token, traceIdHeader);

                var result = new
                {
                    Reponse = new OrderDto()
                    {
                        Product = new ProductDto()
                        {
                            SkuCode = product.SkuCode,
                            Name = product.Name,
                            Price = product.Price
                        },
                        OrderId = Guid.NewGuid()
                    },
                    Request = new { }  
                };

                _logRequestService.AdditionalData = result;

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}