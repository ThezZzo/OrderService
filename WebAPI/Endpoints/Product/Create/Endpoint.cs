using Application.Product.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Product.Create;

public static class Endpoint
{
    public static WebApplication MapCreateProduct(this WebApplication app)
    {
        app.MapPost("/api/products",
            async ([FromBody]Domain.Entities.Product query, ISender mediator) =>
            {
                await mediator.Send(new CreateProductCommand
                {
                    Price = query.Price, 
                    Name = query.Name
                });
            });
        return app;
    }
}