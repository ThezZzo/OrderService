using Domain.Common.Repository;
using Infrastructure.Persistance;
namespace Infrastructure.Repositories.Order;

public class OrderRepository : BaseRepository<Domain.Entities.Order, ApplicationDbContext> , IOrderRepository
{
    protected OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}