using Domain.Common.DTO;
using Domain.Common.Repository;
using Domain.ValueObjects;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Cart;

public class CartRepository : 
    BaseRepository<Domain.Entities.Cart, ApplicationDbContext> , 
    ICartRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Domain.Entities.Cart> _dbCartSet;
    private readonly DbSet<Domain.Entities.CartItem> _dbCartItemSet;
    public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbCartSet = _dbContext.Set<Domain.Entities.Cart>();
        _dbCartItemSet = _dbContext.Set<Domain.Entities.CartItem>();
    }
    
    public async Task<Domain.Entities.Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var cart = await _dbCartSet.Include(p=>p.CartItems).FirstOrDefaultAsync(p => p.Id.Equals(id), cancellationToken);
        if (cart == null)
        {
            throw new Exception();
        }
        return cart;
    }

    public async Task<IEnumerable<CartItemDTO>> GetCartItems(Guid id, CancellationToken cancellationToken)
    {
        var cart = await _dbCartItemSet.Where(p=>p.CartId == id)
            .Include(p=>p.Product)
            .Select(p=> new CartItemDTO
            {
                Product = p.Product,
                Quantity = p.Quantity.Value
            })
            .ToListAsync(cancellationToken);
        return cart;
    }

}