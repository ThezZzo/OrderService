namespace Domain.Common.Repository;

public interface ICartItemRepository : IBaseRepository<CartItem>
{
    Task<List<CartItem>> GetCartItemsFromCart(Guid guid, int productId, CancellationToken cancellationToken);

    Task<CartItem> UpdateQuantityCartItem(CartItem cartItem, CancellationToken cancellationToken);

    Task<bool> RemoveCartItemWithProductFromCart(string guid, int id, CancellationToken cancellationToken);
}