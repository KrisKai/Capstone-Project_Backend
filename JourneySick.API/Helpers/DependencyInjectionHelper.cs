using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.Services;
using JourneySick.Business.Services.ImplServices;
using JourneySick.Data.Repositories;
using JourneySick.Data.Repositories.ImplRepositories;

namespace JourneySick.API.Startup
{
    public static class DependencyInjectionHelper
    {
        public static IServiceCollection SwaggerConfiguration(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
            return services;
        }        
        public static IServiceCollection MapperConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }        
        public static IServiceCollection ServicesConfiguration(this IServiceCollection services)
        {
            //Authorize
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}
