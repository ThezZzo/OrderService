using System.Net;
using Application.Order.Commands.Create;

namespace Application.Cart.Commands.Create;

public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Domain.Entities.Cart>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;
    public CreateCartCommandHandler(ICartRepository cartRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;
    }
    
    public async Task<Domain.Entities.Cart> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var newCartItem = Domain.Entities.CartItem.Create(
            await _productRepository.GetEntityByIdAsync(request.CartItem.Product.Id, cancellationToken), 
            Quantity.Create(request.CartItem.Quantity.Value));
        var newCart = Domain.Entities.Cart.Create(
            new List<Domain.Entities.CartItem>()
            {
                newCartItem
            }, 
            DateTime.UtcNow);
        
        await _cartItemRepository.AddEntityAsync(newCartItem, cancellationToken);
        return await _cartRepository.AddEntityAsync(newCart, cancellationToken);
    }
}