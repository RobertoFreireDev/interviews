namespace order.api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CreateOrderResponse>> CreateOrderAsync(CreateOrderRequest request)
    {
        // TO DO: retrieve customerId from authentication cookie
        var customerId = 2;
        var response = await orderService.CreateOrderAsync(request.Order, customerId);

        return response.Success ? Ok(response) : BadRequest(response);
    }
}