using CatalogApi.Dtos;
using LogLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private ILogRequestService _logRequestService;
        public CatalogController(ILogRequestService logRequestService)
        {
            _logRequestService = logRequestService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(4), token);

                var result = new ProductDto()
                {
                    SkuCode = "9123467",
                    Name = "Ball",
                    Price = "23.40"
                };

                _logRequestService.AdditionalData = new
                {
                    Reponse = result
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}