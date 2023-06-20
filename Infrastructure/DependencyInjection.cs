using System.Diagnostics.CodeAnalysis;
using Infrastructure.Repositories.Order;
using Infrastructure.Repositories.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ProductRepository>();
        services.AddScoped<OrderRepository>();
        return services;
    }
}