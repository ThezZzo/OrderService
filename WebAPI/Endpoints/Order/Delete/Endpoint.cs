using Application.Order.Commands.Delete;
using Application.Product.Commands.Delete;
using MediatR;

namespace WebAPI.Endpoints.Order.Delete;

public static class Endpoint
{
    public static WebApplication MapDeleteOrder(this WebApplication app)
    {
        app.MapPut("/api/orders/{id}",
            async (int id, ISender mediator) =>
            {
                await mediator.Send(new DeleteOrderCommand
                {
                    Id = id
                });
            });
        return app;
    }
}