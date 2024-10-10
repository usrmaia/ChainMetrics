using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ChainMetrics.Application.Services;
using ChainMetrics.Application.Interfaces;
using ChainMetrics.Domain.Repositories;
using ChainMetrics.Infra.Data.Repositories;

namespace ChainMetrics.Infra.IOC;

public static class DependencyInjectionSetup
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);

        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();

        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IOrderRepository, OrderRepository>();

        services.AddTransient<IPaymentService, PaymentService>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();

        services.AddTransient<IOrderProductService, OrderProductService>();
        services.AddTransient<IOrderProductRepository, OrderProductRepository>();

        return services;
    }
}
