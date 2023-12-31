﻿using System.Net;
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
        var quantity = Quantity.Create(request.Quantity);
        var product = await _productRepository.GetEntityByIdAsync(request.Product.Id, cancellationToken);
        var newCartItem = Domain.Entities.CartItem.Create(product, quantity);
        var newCart = Domain.Entities.Cart.Create(
            new List<Domain.Entities.CartItem>
            {
                newCartItem
            }, 
            DateTime.UtcNow);
        
        
        return await _cartRepository.AddEntityAsync(newCart, cancellationToken);
    }
}