using Gateway.Clients;
using Gateway.Configuration;

namespace Gateway.Extensions
{
    public static class ConfigurationExtension
    {
        public static void ConfigureGate(this IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.AddJsonFile("GatewayConfiguration.json");
        }

        public static GatewayConfig ConfigureSection(this IConfiguration configurationSection)
        {
            var section = configurationSection.GetSection(nameof(GatewayConfig));
            return section.Get<GatewayConfig>();
        }

        public static void AddGateConfiguration(this IServiceCollection services, GatewayConfig gatewayConfig)
        {
            services.AddSingleton(gatewayConfig);

            services.AddHttpClient<IOrderClient, OrderClient>(client =>
            {
                client.BaseAddress = new Uri("http://orderapi:4002");
                client.Timeout = TimeSpan.FromSeconds(8);
            });
        }
    }
}
