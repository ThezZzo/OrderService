using Application.Order.Queries.GetAllOrders;
using MediatR;

namespace WebAPI.Endpoints.Order.ReturnAllOrders.V1;

public static class Endpoint
{
    
    public static WebApplication MapGetAllOrders(this WebApplication app)
    {
        app.MapGet("/api/orders", async (ISender mediator) => 
            await mediator.Send(new GetAllOrdersQuery()));
        return app;
    }
}