using Domain.Common.Repository;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Cart;

public class CartRepository : 
    BaseRepository<Domain.Entities.Cart, ApplicationDbContext> , 
    ICartRepository
{
    private readonly DbContext _dbContext;
    private readonly DbSet<Domain.Entities.Cart> _dbSet;

    public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<Domain.Entities.Cart>();
    }
    
    public async Task<Domain.Entities.Cart> GetEntityByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var cart = await _dbSet.FindAsync(id, cancellationToken);
        if (cart == null)
        {
            throw new Exception();
        }
        return cart;
    }
}