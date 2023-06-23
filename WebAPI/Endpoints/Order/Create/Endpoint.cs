using Application.Order.Commands.Create;
using Application.Product.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Order.Create;

public static class Endpoint
{
    public static WebApplication MapCreateOrder(this WebApplication app)
    {
        app.MapPost("/api/orders",
            async ([FromBody]Domain.Entities.Order query, ISender mediator) =>
            {
                await mediator.Send(new CreateOrderCommand
                {
                    Count = query.Count,
                    ProductId = query.ProductId
                });
            });
        return app;
    }
}