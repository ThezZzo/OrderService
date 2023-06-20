using Application.Product.Queries.AllProducts;
using MediatR;

namespace WebAPI.Endpoints.Product.GetAll;

public static class Endpoint
{
    
    public static WebApplication MapGetAllProduct(this WebApplication app)
    {
        app.MapGet("api/products", async (IMediator mediator) => 
            await mediator.Send(new GetAllProductQuery()));
        return app;
    }
}