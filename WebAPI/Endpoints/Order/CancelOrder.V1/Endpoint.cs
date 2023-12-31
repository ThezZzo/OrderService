﻿using Application.Order.Commands.Delete;
using MediatR;

namespace WebAPI.Endpoints.Order.CancelOrder.V1;

public static class Endpoint
{
    public static WebApplication MapDeleteOrder(this WebApplication app)
    {
        app.MapDelete("/api/orders/{id}",
            async (int id, ISender mediator) =>
            {
                await mediator.Send(new DeleteOrderCommand
                {
                    Id = id
                });
            });
        return app;
    }
}