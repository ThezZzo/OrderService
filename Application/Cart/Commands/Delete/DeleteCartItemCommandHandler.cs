using Application.Cart.Commands.Create;
using Infrastructure.Persistance;

namespace Application.Cart.Commands.Delete;

public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, bool>
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IProductRepository _productRepository;
    
    public DeleteCartItemCommandHandler(ICartRepository cartRepository, 
        ICartItemRepository cartItemRepository, 
        IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _productRepository = productRepository;

    }
    
    public async Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {

        return await _cartItemRepository.RemoveCartItemWithProductFromCart(request.CartId, request.ProductId,
            cancellationToken);
    }
}