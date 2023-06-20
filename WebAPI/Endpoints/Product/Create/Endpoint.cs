using Application.Product.Commands.Create;
using MediatR;
using Application.Product.Queries.AllProducts;
namespace WebAPI.Endpoints.Product.Create;

public static class Endpoint
{

    public static WebApplication MapPostCreateProduct(this WebApplication app)
    {
        app.MapPost("api/products", async (CreateProductCommand request, Mediator mediator) =>
        {
            var response = await mediator.Send(new GetAllProductQuery { });
        });
        return app;
    }
    
    
}