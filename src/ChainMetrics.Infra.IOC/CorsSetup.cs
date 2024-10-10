using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

using ChainMetrics.Domain.Exceptions;

namespace ChainMetrics.Infra.IOC;

public static class CorsSetup
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: configuration["Cors:PolicyName"] ?? throw new AppException("Cors: PolicyName is null!", HttpStatusCode.InternalServerError), builder =>
            {
                builder.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("Authorization", "Content-Type");
            });
        });

        return services;
    }
}