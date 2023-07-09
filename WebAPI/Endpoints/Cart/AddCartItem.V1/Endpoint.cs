using Application.Cart.Commands.Update;
using Domain.Common.DTO;
using MediatR;

namespace WebAPI.Endpoints.Cart.AddCartItem.V1;

public static class Endpoint
{
    public static WebApplication MapAddCartItem(this WebApplication app)
    {
        app.MapPost("/api/cart/{id}",
            async (CartItemDTO cartItem, string id,ISender mediator) =>
            {
                await mediator.Send(new AddCartItemCommand
                {
                    CartId = id,
                    Product = cartItem.Product,
                    Quantity = cartItem.Quantity
                });
            });
        return app;
    }
}