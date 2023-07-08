using Domain.Common.DTO;
using Domain.Common.Repository;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Cart;

public class CartRepository : 
    BaseRepository<Domain.Entities.Cart, ApplicationDbContext> , 
    ICartRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Domain.Entities.Cart> _dbCartSet;

    public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbCartSet = _dbContext.Set<Domain.Entities.Cart>();

    }
    
    public async Task<Domain.Entities.Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var cart = await _dbCartSet.FirstOrDefaultAsync(p=>p.Id == id, cancellationToken);
        if (cart == null)
        {
            throw new Exception();
        }
        return cart;
    }

    public async Task<List<Domain.Entities.Cart>> GetCartItems(Guid id, CancellationToken cancellationToken)
    {
        var cartItems = await _dbCartSet.Where(p => p.Id == id).Include(p => p.CartItems)
            .ToListAsync(cancellationToken);
        if (cartItems == null)
        {
            throw new Exception();
        }
        
        return cartItems;
    }
}