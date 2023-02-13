using JourneySick.Data;
using Microsoft.EntityFrameworkCore;

namespace JourneySick.API.Startup
{
    public static class CorsHelper
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            return services;
        }
    }
}
