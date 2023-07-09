using System.Diagnostics.CodeAnalysis;
using System.Net.NetworkInformation;
using Application.Cart.Commands.Create;
using Application.Cart.Commands.Delete;
using Application.Cart.Commands.Update;
using Application.Cart.Queries.GetCart;
using Application.Order.Commands.Create;
using Application.Order.Commands.Delete;
using Application.Order.Commands.Update;
using Application.Order.Queries.GetAllOrders;
using Application.Product.Commands.Create;
using Application.Product.Commands.Delete;
using Application.Product.Queries.AllProducts;
using Application.Product.Queries.GetProduct;
using Domain.Common.DTO;
using Domain.Common.Repository;
using Domain.Entities;
using Infrastructure.Repositories.Cart;
using Infrastructure.Repositories.CartItem;
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
        
        //Сущность Product
        services.AddScoped(typeof(IRequestHandler<GetAllProductQuery, IEnumerable<Product>>), typeof(GetAllProductQueryHandler));
        services.AddScoped(typeof(IRequestHandler<GetProductQuery, Product>), typeof(GetProductQueryHandler));
        services.AddScoped(typeof(IRequestHandler<CreateProductCommand, Product>), typeof(CreateProductCommandHandler));
        services.AddScoped(typeof(IRequestHandler<DeleteProductCommand, bool>), typeof(DeleteProductCommandHandler));
        services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        //
        
        //Сущность Order
        services.AddScoped(typeof(IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>), typeof(GetAllOrdersQueryHandler));
        services.AddScoped(typeof(IRequestHandler<CreateOrderCommand, Order>), typeof(CreateOrderCommandHandler));
        // services.AddScoped(typeof(IRequestHandler<UpdateOrderCommand, Unit>), typeof(UpdateOrderCommandHandler));
        services.AddScoped(typeof(IRequestHandler<DeleteOrderCommand, bool>), typeof(DeleteOrderCommandHandler));
        services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
        //
        
        //Сущность Cart
        services.AddScoped(typeof(IRequestHandler<GetCartQuery, IEnumerable<CartItemDTO>>), typeof(GetCartCommandHandler));
        services.AddScoped(typeof(IRequestHandler<AddCartItemCommand, Cart>), typeof(AddCartItemCommandHandler));
        services.AddScoped(typeof(IRequestHandler<CreateCartCommand, Cart>), typeof(CreateCartCommandHandler));
        services.AddScoped(typeof(IRequestHandler<DeleteCartItemCommand, bool>), typeof(DeleteCartItemCommandHandler));
        services.AddScoped(typeof(ICartRepository), typeof(CartRepository));
        
        services.AddScoped(typeof(ICartItemRepository), typeof(CartItemRepository));
        return services;
    }
    public static WebApplication ConfigureMapApi(this WebApplication app)
    {
        return app;
    }
}