﻿namespace Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, ICartRepository cartRepository)
     {
         _orderRepository = orderRepository;
         _cartRepository = cartRepository;
     }
     
     public async Task<Domain.Entities.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
     {
         var cart = await _cartRepository.GetEntityByGuidAsync(Guid.Parse(request.CartId), cancellationToken);
         if (cart.CartIsClosed())
         {
             throw new Exception();
         }
         cart.CloseCartForCheckoutOrder();
         var cartItems = _cartRepository.GetCartItems(Guid.Parse(request.CartId), cancellationToken);
         var price = Domain.Entities.Cart.CalculateFinalPrice(await cartItems);
         var entity = Domain.Entities.Order.Create(cart, SumPrice.Create(price));
         return await _orderRepository.AddEntityAsync(entity, cancellationToken);
     }
}