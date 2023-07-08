using Domain.Common.DTO;

namespace Domain.Common.Repository;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Cart>> GetCartItems(Guid id, CancellationToken cancellationToken);
}