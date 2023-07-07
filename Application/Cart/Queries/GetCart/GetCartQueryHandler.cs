namespace Application.Cart.Queries.GetCart;

public class GetCartCommandHandler : IRequestHandler<GetCartQuery, Domain.Entities.Cart>
{
    private readonly ICartRepository _cartRepository;

    public GetCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
     
    public async Task<Domain.Entities.Cart> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return await _cartRepository.GetEntityByGuidAsync(request.CartId, cancellationToken);
    }
}