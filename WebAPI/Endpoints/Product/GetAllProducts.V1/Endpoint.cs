using Application.Product.Queries.AllProducts;
using MediatR;

namespace WebAPI.Endpoints.Product.GetAllProducts.V1;

public static class Endpoint
{
    
    public static WebApplication MapGetAllProduct(this WebApplication app)
    {
        app.MapGet("/api/products", async (ISender mediator) => 
            await mediator.Send(new GetAllProductQuery()));
        return app;
    }
}