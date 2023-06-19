using MediatR;
using Application.Product.Queries.AllProducts;
namespace WebAPI.Endpoints.Product.Create;

public class Endpoint
{
    private readonly IMediator _mediator;
    
    public Endpoint(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
}