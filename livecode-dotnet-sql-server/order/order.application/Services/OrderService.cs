namespace order.application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderDto order, int customerId)
    {
        var newOrder = new Order()
        {
            Customer = new Customer() { Id = customerId },
                Items = order.Items.Select(i => new OrderItem()
                {
                    Price = i.Price,
                    Quantity = i.Quantity,
                    Product = new Product() { Id = i.ProductId },
                }).ToList(),
            TotalPrice = order.TotalPrice,
        };
        return new CreateOrderResponse()
        {
            Success = await orderRepository.CreateOrderAsync(newOrder)
        };
    }
}
