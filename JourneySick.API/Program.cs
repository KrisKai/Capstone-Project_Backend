using AutoMapper;
using JourneySick.API.Startup;
using JourneySick.Business.Helpers;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();

builder.Services.AddControllers();

builder.Services.DatabaseSetup(builder.Configuration);

builder.Services.AddServicesConfiguration();

builder.Services.AddMapperConfiguration();

builder.Services.AddSwaggerServices();

builder.Services.AddJWTServices(builder.Configuration);

builder.Services.AddSettingObjects(builder.Configuration);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.ConfigureSwagger();

//use CORS must be placed between UseRouting and UseEndpoints if they exist ok?
//app.UseRouting();
app.UseCors("CorsPolicy");
//app.UseEndpoints();

// global error handler
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
