using JourneySick.Data;
using JourneySick.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JourneySick.API.Startup
{
    public static class DatabaseHelper
    {
        public static IServiceCollection DatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<journeysick_dbContext>(
            options =>
            {
                options.UseMySql(configuration.GetConnectionString("DEV_PHAT"),
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));
            });
            return services;
        }
    }
}
