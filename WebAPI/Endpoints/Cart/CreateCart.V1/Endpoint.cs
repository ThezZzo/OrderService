using Application.Cart.Commands.Create;
using Application.Order.Commands.Delete;
using Domain.Entities;
using MediatR;

namespace WebAPI.Endpoints.Cart.CreateCart.V1;

public static class Endpoint
{
    public static WebApplication MapCreateCart(this WebApplication app)
    {
        app.MapPost("/api/cart",
            async (Domain.Entities.CartItem cartItem, ISender mediator) =>
            {
                await mediator.Send(new CreateCartCommand
                {
                    CartItem = cartItem
                });
            });
        return app;
    }
}