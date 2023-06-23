using Application.Product.Commands.Create;
using MediatR;
using Application.Product.Queries.AllProducts;
namespace WebAPI.Endpoints.Product.Create;

public static class Endpoint
{
    public static WebApplication MapCreateProduct(this WebApplication app)
    {
        app.MapGet("api/products",
            async (Domain.Entities.Product query, ISender mediator) =>
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