using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using Application.Order.Commands.Create;
using Application.Order.Commands.Delete;
using Application.Order.Commands.Update;
using Application.Order.Queries.GetAllOrders;
using Application.Product.Commands.Create;
using Application.Product.Commands.Delete;
using Application.Product.Queries.AllProducts;
using Application.Product.Queries.GetProduct;
using Domain.Common.DTOs;
using Domain.Common.Repository;
using Domain.Entities;
using Infrastructure.Repositories.Order;
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
        services.AddScoped(typeof(IRequestHandler<GetProductQuery, Product>), typeof(GetProductQueryHandler));
        services.AddScoped(typeof(IRequestHandler<CreateProductCommand, Product>), typeof(CreateProductCommandHandler));
        services.AddScoped(typeof(IRequestHandler<DeleteProductCommand, bool>), typeof(DeleteProductCommandHandler));
        services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        
        services.AddScoped(typeof(IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>), typeof(GetAllOrdersQueryHandler));
        services.AddScoped(typeof(IRequestHandler<CreateOrderCommand, Order>), typeof(CreateOrderCommandHandler));
        // services.AddScoped(typeof(IRequestHandler<UpdateOrderCommand, Unit>), typeof(UpdateOrderCommandHandler));
        services.AddScoped(typeof(IRequestHandler<DeleteOrderCommand, bool>), typeof(DeleteOrderCommandHandler));
        services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
        
        return services;
    }
    public static WebApplication ConfigureMapApi(this WebApplication app)
    {
        return app;
    }
}