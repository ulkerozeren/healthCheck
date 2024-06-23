using AutoMapper;
using HealthCheck.API.Mapping;
using HealthCheck.Business.Abstraction;
using HealthCheck.Business.Services;
using HealthCheck.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HealthCheck.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterMappers(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ApiMappingProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(typeof(IMapper), _ => mapper);

            return services;
        }

        //public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration["ConnectionStrings:SqlServer"]).EnableSensitiveDataLogging());

        //    return services;
        //}

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IUserService, UserService>();
  
            return services;
        }

        public static IServiceCollection RegisterHttpContext(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }


    }
}
