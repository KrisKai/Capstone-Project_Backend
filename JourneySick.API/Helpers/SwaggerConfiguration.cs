namespace JourneySick.API.Startup
{
    public static class SwaggerConfiguration
    {
        public static WebApplication ConfigureSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JourneySick.API v1"));
            }
            return app;
        }
    }
}
