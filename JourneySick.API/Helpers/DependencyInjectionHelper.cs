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
    }
}
