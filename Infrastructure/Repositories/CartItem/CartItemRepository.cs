using Domain.Common.Repository;
using Domain.ValueObjects;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CartItem;

public class CartItemRepository : 
    BaseRepository<Domain.Entities.CartItem, ApplicationDbContext> , 
    ICartItemRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Domain.Entities.CartItem> _dbSet;
    public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Domain.Entities.CartItem>();
    }

    public Task<List<Domain.Entities.CartItem>> GetCartItemsFromCart(Guid guid, int productId, CancellationToken cancellationToken)
    {
        if (productId < 0)
        {
            throw new Exception();
        }
        var cartItems = _dbSet.Where(p => p.CartId == guid && p.Product.Id == productId).ToListAsync(cancellationToken);
        if (cartItems == null)
        {
            throw new Exception();
        }

        return cartItems;
    }
    
    public async Task<Domain.Entities.CartItem> UpdateQuantityCartItem(Domain.Entities.CartItem cartItem, CancellationToken cancellationToken)
    {
        _dbSet.Attach(cartItem);
        _dbSet.Entry(cartItem).Property(p => p.Quantity).IsModified = true;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return cartItem;
    }

    public async Task<bool> RemoveCartItemWithProductFromCart(string guid, int id, CancellationToken cancellationToken)
    {
        var cart = await _dbSet.Where(p=>p.CartId.Equals(Guid.Parse(guid)))
            .Include(p=>p.Product)
            .ToListAsync(cancellationToken);
        if (!cart.Any() || cart == null)
        {
            throw new Exception();
        }

        var cartItemForDelete = cart.FirstOrDefault(p => p.Product.Id == id);
        if (cartItemForDelete == null)
        {
            throw new Exception();
        }
        _dbContext.Remove(cartItemForDelete);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}