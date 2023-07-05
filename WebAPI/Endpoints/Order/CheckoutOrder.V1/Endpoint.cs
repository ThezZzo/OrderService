using Application.Order.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Order.CheckoutOrder.V1;

public static class Endpoint
{
    public static WebApplication MapCreateOrder(this WebApplication app)
    {
        app.MapPost("/api/orders",
            async ([FromBody]Domain.Entities.Order query, ISender mediator) =>
            {
                await mediator.Send(new CreateOrderCommand
                {
                    OrderItems = query.OrderItems
                });
            });
        return app;
    }
}