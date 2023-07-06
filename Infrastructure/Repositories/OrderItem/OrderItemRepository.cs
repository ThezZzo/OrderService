using Domain.Common.Repository;
using Infrastructure.Persistance;

namespace Infrastructure.Repositories.OrderItem;

public class OrderItemRepository : 
    BaseRepository<Domain.Entities.OrderItem, ApplicationDbContext> , 
    IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}