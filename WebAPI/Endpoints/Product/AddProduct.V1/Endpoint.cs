using Application.Product.Commands.Create;
using Domain.Common.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Product.AddProduct.V1;

public static class Endpoint
{
    public static WebApplication MapCreateProduct(this WebApplication app)
    {
        app.MapPost("/api/products",
            async ([FromBody]ProductDTO query, ISender mediator) =>
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