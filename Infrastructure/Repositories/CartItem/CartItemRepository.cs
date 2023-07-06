using Domain.Common.Repository;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories.CartItem;

public class CartItemRepository : 
    BaseRepository<Domain.Entities.CartItem, ApplicationDbContext> , 
    ICartItemRepository
{
    public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}