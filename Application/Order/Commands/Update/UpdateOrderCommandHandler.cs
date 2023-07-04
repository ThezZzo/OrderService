using Domain.Common.Repository;
using Domain.Exceptions;
using MediatR;

namespace Application.Order.Commands.Update;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    
    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }
    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _orderRepository.GetEntityByIdAsync(request.Id, cancellationToken);
        if (order == null || order.Id != request.Id)
        {
            throw new NotFoundException(nameof(order), request.Id);
        }
        order.Result.Quantity = request.Quantity;
        order.Result.Product = await _productRepository.GetEntityByIdAsync(request.ProductId, cancellationToken);
        return await _orderRepository.UpdateEntityAsync(order.Result, cancellationToken);
    }
}