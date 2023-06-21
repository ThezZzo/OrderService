
using Infrastructure.Repositories.Order;
using MediatR;


namespace Application.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Domain.Entities.Order>>
{
    private readonly OrderRepository _repository;

    public GetAllOrdersQueryHandler(OrderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Domain.Entities.Order>> Handle
        (GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}