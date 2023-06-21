using System.Diagnostics.CodeAnalysis;
using Domain.Common.Repository;
using Infrastructure.Repositories.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ProductRepository>();

        return services;
    }
}