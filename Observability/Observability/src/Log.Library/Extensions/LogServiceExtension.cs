using LogLibrary.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LogLibrary.Extensions
{
    public static class LogServiceExtension
    {
        public static void AddLogService(this IServiceCollection services)
        {
            services.AddScoped<ILogRequestService, LogRequestService>();
        }
    }
}
