
using Infrastructure.Repositories.Order;
using MediatR;


namespace Application.Order.Commands.Delete;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly OrderRepository _repository;

    public DeleteOrderCommandHandler(OrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        return await _repository.RemoveEntityAsync(new Domain.Entities.Order(), request.Id, cancellationToken);
    }
}