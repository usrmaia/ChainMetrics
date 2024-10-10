using AutoFilterer.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ChainMetrics.Infra.IOC;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.UseAutoFiltererParameters();

            setup.SwaggerDoc("v1", new()
            {
                Title = "ChainMetrics.API",
                Version = "v1",
                Description = "",
                Contact = new OpenApiContact
                {
                    Name = "George Maia",
                    Email = "georgemaiaf@gmail.com",
                    Url = new Uri("https://github.com/usrmaia/")
                },

                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/license/mit/"),
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            setup.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}