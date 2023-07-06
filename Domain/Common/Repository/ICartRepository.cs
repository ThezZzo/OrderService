namespace Domain.Common.Repository;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken);
}