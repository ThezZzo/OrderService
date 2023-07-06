using Application.Cart.Commands.Create;
using MediatR;

namespace WebAPI.Endpoints.Cart.AddCartItem;

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