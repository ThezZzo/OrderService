namespace Application.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Domain.Entities.Order>>
{
    private readonly IOrderRepository _repository;

    public GetAllOrdersQueryHandler(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Domain.Entities.Order>> Handle
        (GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders =  await _repository.GetAllOrders(cancellationToken);
        return orders;
    }
}