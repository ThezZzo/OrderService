using Domain.Common.Repository;
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
        var order = new Domain.Entities.Order
        {
            Name = "Заказ",
            Count = request.Count,
            ProductId = request.ProductId,
            Product = await _productRepository.GetEntityByIdAsync(request.ProductId,cancellationToken)
        };
        return await _orderRepository.AddEntityAsync(order, cancellationToken);
    }
}