using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using Application.Product.Queries.AllProducts;
using Domain.Common.Repository;
using Domain.Entities;
using Infrastructure.Repositories.Product;
using MediatR;

namespace WebAPI.Configuration;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection ConfigureMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
        services.AddScoped(typeof(IRequestHandler<GetAllProductQuery, IEnumerable<Product>>), typeof(GetAllProductQueryHandler));
        services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        return services;
    }
}