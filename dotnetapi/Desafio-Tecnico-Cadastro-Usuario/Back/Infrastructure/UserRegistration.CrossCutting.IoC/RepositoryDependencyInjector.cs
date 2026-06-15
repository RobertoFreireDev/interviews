using Microsoft.Extensions.DependencyInjection;
using UserRegistration.DataAccess.Repositories;
using UserRegistration.Domain.Repositories;

namespace UserRegistration.CrossCutting.IoC
{
    public class RepositoryDependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
