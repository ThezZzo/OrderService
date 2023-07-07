﻿namespace Application.Cart.Commands.AddCartItem;

public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, Domain.Entities.Cart>
{
    private readonly ICartRepository _cartRepository;

    public AddCartItemCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
     
    public async Task<Domain.Entities.Cart> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetEntityByGuidAsync(request.CartId, cancellationToken);
        cart.AddCartItem(Domain.Entities.CartItem.Create(request.CartItem.Product, Quantity.Create(request.CartItem.Quantity.Value)));
        await _cartRepository.UpdateEntityAsync(cart, cancellationToken);
        return cart;
    }
}