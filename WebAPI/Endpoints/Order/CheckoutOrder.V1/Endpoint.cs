using Application.Order.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Order.CheckoutOrder.V1;

public static class Endpoint
{
    public static WebApplication MapCreateOrder(this WebApplication app)
    {
        app.MapPost("/api/orders",
            async ([FromBody]Guid cartId, ISender mediator) =>
            {
                await mediator.Send(new CreateOrderCommand
                {
                    CartId = cartId
                });
            });
        return app;
    }
}