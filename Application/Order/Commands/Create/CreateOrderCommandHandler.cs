using Domain.Common.Repository;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
     {
         _orderRepository = orderRepository;
         _orderItemRepository = orderItemRepository;
     }
     
     public async Task<Domain.Entities.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
     {
         var price = Domain.Entities.Order.CalculateFinalPrice(request.OrderItems);
         var entity = Domain.Entities.Order.Create(new List<OrderItem>(), SumPrice.Create(price));
         foreach (var item in request.OrderItems)
         {
             entity.AddOrderItem(
                 Domain.Entities.Product.Create(item.Product.Price, item.Product.Name), 
                 Quantity.Create(item.Quantity.Value));
         }

         await _orderItemRepository.AddListEntityAsync(entity.OrderItems, cancellationToken);
         return await _orderRepository.AddEntityAsync(entity, cancellationToken);
     }
}