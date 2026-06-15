namespace order.application.Services.Interfaces;

public interface IOrderService
{
    Task<CreateOrderResponse> CreateOrderAsync(CreateOrderDto order, int customerId);
}
