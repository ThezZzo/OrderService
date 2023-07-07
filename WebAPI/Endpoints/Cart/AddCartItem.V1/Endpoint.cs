using Application.Cart.Commands.AddCartItem;
using Application.Cart.Commands.Create;
using MediatR;

namespace WebAPI.Endpoints.Cart.AddCartItem;

public static class Endpoint
{
    public static WebApplication MapAddCartItem(this WebApplication app)
    {
        app.MapPatch("/api/cart",
            async (Domain.Entities.CartItem cartItem, Guid id,ISender mediator) =>
            {
                await mediator.Send(new AddCartItemCommand
                {
                    CartId = id,
                    CartItem = cartItem
                });
            });
        return app;
    }
}