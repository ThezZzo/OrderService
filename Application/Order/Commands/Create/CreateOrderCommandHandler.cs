using Domain.Common.Repository;
using Infrastructure.Repositories.Order;
using MediatR;


namespace Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _repository;

    public CreateOrderCommandHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Domain.Entities.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Entities.Order
        {
            Count = request.Count,
            ProductId = request.ProductId
        };
        return await _repository.AddEntityAsync(order, cancellationToken);
    }
}