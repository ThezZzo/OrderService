﻿using Application.Product.Commands.Delete;
using MediatR;

namespace WebAPI.Endpoints.Product.DeleteProduct.V1;

public static class Endpoint
{
    public static WebApplication MapDeleteProduct(this WebApplication app)
    {
        app.MapDelete("/api/products/{id}",
            async (int id, ISender mediator) =>
            {
                await mediator.Send(new DeleteProductCommand()
                {
                    Id = id
                });
            });
        return app;
    }
}