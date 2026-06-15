using Microsoft.Extensions.DependencyInjection;
using UserRegistration.Application.Services.User;
using UserRegistration.Domain.Services.User;

namespace UserRegistration.CrossCutting.IoC
{
    public class ServiceDependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
