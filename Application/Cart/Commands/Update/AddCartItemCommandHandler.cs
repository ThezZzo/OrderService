using Domain.Common.DTO;

namespace Application.Cart.Commands.AddCartItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, Domain.Entities.Cart>
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICartItemRepository _cartItemRepository;
    public AddCartItemCommandHandler(ICartRepository cartRepository, IProductRepository productRepository, ICartItemRepository cartItemRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
        _cartItemRepository = cartItemRepository;
    }
     
    public async Task<Domain.Entities.Cart> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = _cartRepository.GetEntityByGuidAsync(request.CartId, cancellationToken).Result;
        var product = await _productRepository.GetEntityByIdAsync(request.Product.Id, cancellationToken);
        var quantity = Quantity.Create(request.Quantity);
        var newCartItem = Domain.Entities.CartItem.Create(product, quantity);
        // if (cart.CartItems.Find(x=>x.Product.Id == newCartItem.Product.Id) != null);
        // {
        //     var cartItem = cart.GetCartItem(cart.CartItems, product);
        //     cartItem.UpdateQuantity(cartItem, quantity);
        //     return await _cartRepository.UpdateEntityAsync(cart, cancellationToken);
        // } 
        cart.AddCartItem(newCartItem);
        await _cartItemRepository.AddEntityAsync(newCartItem, cancellationToken);
        return cart;
    }
}