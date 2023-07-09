using Domain.Common.DTO;

namespace Domain.Common.Repository;

public interface ICartRepository : IBaseRepository<Cart>
{
    Task<Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<CartItemDTO>> GetCartItems(Guid id, CancellationToken cancellationToken);

    Task<List<CartItem>> DeleteProductFromCart(Guid guid, int id,
        CancellationToken cancellationToken);
}