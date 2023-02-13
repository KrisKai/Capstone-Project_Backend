using AutoMapper;
using JourneySick.API.Startup;
using JourneySick.Business.Helpers;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();

builder.Services.AddControllers();

builder.Services.DatabaseSetup(builder.Configuration);

builder.Services.ServicesConfiguration();

builder.Services.MapperConfiguration();

builder.Services.SwaggerConfiguration();

var app = builder.Build();

app.ConfigureSwagger();

//use CORS must be placed between UseRouting and UseEndpoints if they exist ok?
//app.UseRouting();
app.UseCors("CorsPolicy");
//app.UseEndpoints();

// global error handler
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
