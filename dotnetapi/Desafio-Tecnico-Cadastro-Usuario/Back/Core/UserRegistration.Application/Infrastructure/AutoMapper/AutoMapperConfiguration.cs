using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using UserRegistration.Application.Infrastructure.AutoMapper.Profiles;

namespace UserRegistration.Application.Infrastructure.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration =  new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });


            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
