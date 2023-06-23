using Application.Order.Queries.GetAllOrders;
using Application.Product.Queries.AllProducts;
using MediatR;

namespace WebAPI.Endpoints.Order.GetAll;

public static class Endpoint
{
    
    public static WebApplication MapGetAllOrders(this WebApplication app)
    {
        app.MapGet("/api/orders", async (ISender mediator) => 
            await mediator.Send(new GetAllOrdersQuery()));
        return app;
    }
}