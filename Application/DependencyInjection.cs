using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Domain.Common.Repository;
using Infrastructure.Repositories.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        return services;
    }
}