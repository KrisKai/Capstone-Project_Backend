using AutoMapper;
using JourneySick.Business.Helpers;
using JourneySick.Business.IServices;
using JourneySick.Business.IServices.Services;
using JourneySick.Data.IRepositories;
using JourneySick.Data.IRepositories.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace JourneySick.API.Startup
{
    public static class DependencyInjectionHelper
    {   
        public static IServiceCollection AddMapperConfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }        
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            //Authorize
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserDetailRepository, UserDetailRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticateService, AuthenticateService>();
            services.AddTransient<ITripService, TripService>();
            services.AddTransient<ITripRepository, TripRepository>();
            services.AddTransient<ITripPlanService, TripPlanService>();
            services.AddTransient<ITripPlanRepository, TripPlanRepository>();
            services.AddTransient<ITripMemberService, TripMemberService>();
            services.AddTransient<ITripMemberRepository, TripMemberRepository>();
            services.AddTransient<ITripDetailRepository, TripDetailRepository>();
            services.AddTransient<ITripRoleService, TripRoleService>();
            services.AddTransient<ITripRoleRepository, TripRoleRepository>();
            services.AddTransient<ITripItemService, TripItemService>();
            services.AddTransient<ITripItemRepository, TripItemRepository>();
            services.AddTransient<IPlanLocationService, PlanLocationService>();
            services.AddTransient<IPlanLocationRepository, PlanLocationRepository>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IMapLocationRepository, MapLocationRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IItemCategoryRepository, ItemCategoryRepository>();
            services.AddTransient<IItemCategoryService, ItemCategoryService>();
            services.AddTransient<ITripRouteService, TripRouteService>();
            services.AddTransient<ITripRouteRepository, TripRouteRepository>();
            services.AddTransient<IRoutePlanRepository, RoutePlanRepository>();

            return services;
        }

        public static IServiceCollection AddSettingObjects(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Strongly Typed Settings Objects
            ///Secret key
            var appSettingsSection = configuration.GetSection("AppSecrect");
            services.Configure<AppSecrect>(appSettingsSection);

            return services;
        }


        public static IServiceCollection AddJWTServices(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSecrect");
            services.Configure<AppSecrect>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSecrect>();
            var key = Encoding.ASCII.GetBytes(appSettings.JwtSecrect);

            //JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JourneySick.API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer YOUR_TOKEN_HERE\"",

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}
                     }
                 });
            });

            return services;
        }

    }
}
