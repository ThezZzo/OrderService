using Application.Product.Queries.GetProduct;
using MediatR;


namespace WebAPI.Endpoints.Product.GetById;

public static class Endpoint
{
    
    public static WebApplication MapGetProductById(this WebApplication app)
    {
        app.MapGet("/api/products/{id}", async (int id, ISender mediator) => 
            await mediator.Send(new GetProductQuery
            {
                Id = id
            }));
        return app;
    }
}