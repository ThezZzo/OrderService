using Application.Cart.Commands.Create;
using Domain.Common.DTO;
using Domain.Entities;
using MediatR;

namespace WebAPI.Endpoints.Cart.CreateCart.V1;

public static class Endpoint
{
    public static WebApplication MapCreateCart(this WebApplication app)
    {
        app.MapPost("/api/cart",
            async (CartItemDTO cartItem, ISender mediator) =>
            {
                await mediator.Send(new CreateCartCommand
                {
                    Product = cartItem.Product,
                    Quantity = cartItem.Quantity
                });
            });
        return app;
    }
}