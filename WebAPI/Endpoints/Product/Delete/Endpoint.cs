using Application.Product.Commands.Create;
using Application.Product.Commands.Delete;
using MediatR;

namespace WebAPI.Endpoints.Product.Delete;

public static class Endpoint
{
    public static WebApplication MapDeleteProduct(this WebApplication app)
    {
        app.MapPut("/api/products/{id}",
            async (int id, ISender mediator) =>
            {
                await mediator.Send(new DeleteProductCommand()
                {
                    Id = id
                });
            });
        return app;
    }
}