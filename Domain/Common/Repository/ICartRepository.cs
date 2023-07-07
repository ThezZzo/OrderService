namespace Domain.Common.Repository;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.CartItem>> GetCartItems(Guid id, CancellationToken cancellationToken);
}