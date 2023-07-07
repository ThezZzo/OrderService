namespace Application.Cart.Queries.GetCart;

public class GetCartCommandHandler : IRequestHandler<GetCartQuery, IList<Domain.Entities.CartItem>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
     
    public async Task<IList<Domain.Entities.CartItem>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return await _cartRepository.GetCartItems(request.CartId, cancellationToken);
    }
}