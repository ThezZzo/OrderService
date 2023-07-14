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

        var cartItems = await _cartRepository.GetCartItems(guid, cancellationToken);
        if (cart.CartItems.Find(p => p.Product.Id == request.Product.Id) != null)
        {
            
        }

        foreach (var item in cartItems)
        {
            if (item.Product.Id == request.Product.Id)
            {
                
                await _cartItemRepository.UpdateQuantityCartItem(new Domain.Entities.CartItem
                {
                    Quantity = Quantity.Create(item.Quantity + request.Quantity)
                }, cancellationToken);
                return cart;
            }
        }
        var product = await _productRepository.GetEntityByIdAsync(request.Product.Id, cancellationToken);
        var quantity = Quantity.Create(request.Quantity);
        var newCartItem = Domain.Entities.CartItem.Create(product, quantity);
        
        cart.CartItems.Add(newCartItem);
        await _cartItemRepository.AddEntityAsync(newCartItem, cancellationToken);
        return cart;
    }
}