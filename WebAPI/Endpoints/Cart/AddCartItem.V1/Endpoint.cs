using Application.Cart.Commands.Create;
using Application.Cart.Commands.Update;
using Domain.Common.DTO;
using MediatR;

namespace WebAPI.Endpoints.Cart.AddCartItem;

public static class Endpoint
{
    public static WebApplication MapAddCartItem(this WebApplication app)
    {
        app.MapPatch("/api/cart",
            async (CartItemDTO cartItem, Guid id,ISender mediator) =>
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