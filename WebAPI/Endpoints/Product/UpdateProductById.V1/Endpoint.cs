using Application.Product.Commands.Update;
using Domain.Common.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Product.UpdateProductById.V1;

public static class Endpoint
{
    
    public static WebApplication MapUpdateProduct(this WebApplication app)
    {
        app.MapPut("/api/products/{id}", async ([FromBody] ProductDTO query, int id, ISender mediator) => 
            await mediator.Send(new UpdateProductCommand
            {
                Name = query.Name,
                Price = query.Price,
                ProductId = id
            }));
        return app;
    }
}