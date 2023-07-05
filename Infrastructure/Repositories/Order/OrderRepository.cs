using Domain.Common.Repository;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Order;

public class OrderRepository : 
    BaseRepository<Domain.Entities.Order, ApplicationDbContext> , 
    IOrderRepository
{
    private readonly DbContext _dbContext;
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Domain.Entities.Order>> GetAllOrders(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Domain.Entities.Order>()
            .Include(p => p.OrderItems)
            .ToListAsync(cancellationToken);
    }
}