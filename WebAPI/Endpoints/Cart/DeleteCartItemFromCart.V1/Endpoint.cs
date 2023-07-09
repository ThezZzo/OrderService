using Application.Cart.Commands.Create;
using Application.Cart.Commands.Delete;
using Domain.Common.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Cart.DeleteCartItemFromCart.V1;

public static class Endpoint
{
    public static WebApplication MapDeleteCartItemFromCart(this WebApplication app)
    {
        app.MapDelete("/api/cart/",
            async ([FromBody] DeleteCartItemDto cartItem, ISender mediator) =>
            {
                await mediator.Send(new DeleteCartItemCommand
                {
                    CartId = cartItem.CartId,
                    ProductId = cartItem.ProductId
                });
            });
        return app;
    }
}