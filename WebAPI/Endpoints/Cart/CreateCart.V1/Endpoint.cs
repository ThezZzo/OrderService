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
            async (CartItem cartItem, ISender mediator) =>
            {
                await mediator.Send(new CreateCartCommand
                {
                    CartItem = cartItem
                });
            });
        return app;
    }
}