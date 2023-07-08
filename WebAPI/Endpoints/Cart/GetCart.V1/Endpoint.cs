using Application.Cart.Queries.GetCart;
using MediatR;

namespace WebAPI.Endpoints.Cart.GetCart.V1;

public static class Endpoint
{
    public static WebApplication MapGetCart(this WebApplication app)
    {
        app.MapGet("/api/cart/{id}",
            async (string id, ISender mediator) =>
            {
                await mediator.Send(new GetCartQuery
                {
                    CartId = Guid.Parse(id)
                });
            });
        return app;
    }
}