using Domain.Common.Repository;
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
    

}