using Domain.Common.Repository;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
     {
         _orderRepository = orderRepository;
         _productRepository = productRepository;
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
         
         return await _orderRepository.AddEntityAsync(entity, cancellationToken);
     }
}