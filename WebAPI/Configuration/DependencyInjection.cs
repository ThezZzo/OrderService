using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using Application.Product.Commands.Create;
using Application.Product.Commands.Delete;
using Application.Product.Queries.AllProducts;
using Application.Product.Queries.GetProduct;
using Domain.Common.Repository;
using Domain.Entities;
using Infrastructure.Repositories.Product;
using MediatR;
using WebAPI.Endpoints.Product.Create;
using WebAPI.Endpoints.Product.Delete;
using WebAPI.Endpoints.Product.GetAll;
using WebAPI.Endpoints.Product.GetById;

namespace WebAPI.Configuration;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection ConfigureMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));
        services.AddScoped(typeof(IRequestHandler<GetAllProductQuery, IEnumerable<Product>>), typeof(GetAllProductQueryHandler));
        services.AddScoped(typeof(IRequestHandler<GetProductQuery, Product>), typeof(GetProductQueryHandler));
        services.AddScoped(typeof(IRequestHandler<CreateProductCommand, Product>), typeof(CreateProductCommandHandler));
        services.AddScoped(typeof(IRequestHandler<DeleteProductCommand, bool>), typeof(DeleteProductCommandHandler));
        services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        return services;
    }
    public static WebApplication ConfigureMapApi(this WebApplication app)
    {

        return app;
    }
}