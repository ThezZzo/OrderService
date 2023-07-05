namespace Domain.Common.Repository;

public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<IEnumerable<Order>> GetAllOrders(CancellationToken cancellationToken);
}