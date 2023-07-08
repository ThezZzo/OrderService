namespace Application.Cart.Queries.GetCart;

public class GetCartCommandHandler : IRequestHandler<GetCartQuery, List<Domain.Entities.Cart>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
     
    public async Task<List<Domain.Entities.Cart>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return await _cartRepository.GetCartItems(request.CartId, cancellationToken);
    }
}