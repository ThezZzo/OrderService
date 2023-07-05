using Domain.Common.Repository;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Repositories.OrderItem;

public class OrderItemRepository : 
    BaseRepository<Domain.Entities.OrderItem, ApplicationDbContext> , 
    IOrderItemRepository
{
    public OrderItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}