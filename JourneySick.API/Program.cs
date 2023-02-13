using JourneySick.API.Startup;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();

builder.Services.AddControllers();

builder.Services.DatabaseSetup(builder.Configuration);

builder.Services.SwaggerConfiguration();



var app = builder.Build();

app.ConfigureSwagger();

//use CORS must be placed between UseRouting and UseEndpoints if they exist ok?
//app.UseRouting();
app.UseCors("CorsPolicy");
//app.UseEndpoints();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
