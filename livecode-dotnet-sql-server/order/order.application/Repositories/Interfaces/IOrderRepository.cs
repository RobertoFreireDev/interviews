namespace order.application.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<bool> CreateOrderAsync(Order order);
}
