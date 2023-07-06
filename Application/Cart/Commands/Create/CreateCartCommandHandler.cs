using System.Net;
using Application.Order.Commands.Create;

namespace Application.Cart.Commands.Create;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Domain.Entities.Cart>
{
    private readonly ICartRepository _cartRepository;

    public CreateCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
     
    public async Task<Domain.Entities.Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var newCart = Domain.Entities.Cart.Create(new List<Domain.Entities.CartItem>(), DateTime.UtcNow);
        var cart = await _cartRepository.GetEntityByGuidAsync(request.CartId, cancellationToken);
        cart.AddCartItem(request.CartItem);
        return cart;
    }
}