namespace order.api.IoC;

public static class IoC
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();

        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
