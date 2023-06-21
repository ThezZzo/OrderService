using Infrastructure.Repositories.Order;
using MediatR;


namespace Application.Order.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Domain.Entities.Order>
{
    private readonly OrderRepository _repository;

    public CreateOrderCommandHandler(OrderRepository repository)
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