using Application.Cart.Commands.Create;

namespace Application.CartItem.Commands.Create;

public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, Domain.Entities.CartItem>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;
    
    public CreateCartItemCommandHandler
    (
        ICartItemRepository cartItemRepository, 
        IProductRepository productRepository,
        ICartRepository cartRepository) {
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }
     
    public async Task<Domain.Entities.CartItem> Handle(CreateCartItemCommand request, CancellationToken cancellationToken) {
        var product = _productRepository.GetEntityByIdAsync(request.productId,cancellationToken).Result;
        var cart = _cartRepository.GetEntityByIdAsync(request.CartId, cancellationToken).Result;
        var cartItem = Domain.Entities.CartItem.Create(product, Quantity.Create(request.Quantity));
        cart.AddCartItem(cartItem);
        return await _cartItemRepository.AddEntityAsync(cartItem, cancellationToken);
    }
}