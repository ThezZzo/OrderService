using System.Data.Common;
using Infrastructure.Configuration;
using Infrastructure.Persistance;

namespace Application.Cart.Commands.Update;

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
        Guid guid = Guid.Parse(request.CartId);
        
        var cart = _cartRepository.GetEntityByGuidAsync(guid, cancellationToken).Result;
        if (cart.CloseCart == true)
        {
            throw new Exception();
        }
        var product = await _productRepository.GetEntityByIdAsync(request.Product.Id, cancellationToken);
        var quantity = Quantity.Create(request.Quantity);
        var cartItems = _cartItemRepository.GetCartItemsFromCart(guid, request.Product.Id, cancellationToken).Result;
        foreach (var item in cartItems.Where(i=>i.Product.Id == request.Product.Id))
        {
            var cartItem = item;
            cartItem.Quantity = Quantity.Create(request.Quantity + item.Quantity.Value);
            await _cartItemRepository.UpdateEntityAsync(cartItem, cancellationToken);
            return cart;
        }


        var newCartItem = Domain.Entities.CartItem.Create(product, quantity);
        
        cart.CartItems.Add(newCartItem);
        await _cartItemRepository.AddEntityAsync(newCartItem, cancellationToken);
        return cart;
    }
}