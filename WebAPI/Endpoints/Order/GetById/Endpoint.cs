using Application.Product.Queries.GetProduct;
using MediatR;

namespace WebAPI.Endpoints.Order.GetById;

public static class Endpoint
{
    
    // public static WebApplication MapGetOrderById(this WebApplication app)
    // {
    //     app.MapGet("/api/products/{id}", async (int id, ISender mediator) => 
    //         await mediator.Send(new GetProductQuery
    //         {
    //             Id = id
    //         }));
    //     return app;
    // }
}