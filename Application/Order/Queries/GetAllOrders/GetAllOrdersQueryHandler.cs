using Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrderList>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllOrdersQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<OrderList> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _dbContext.Orders.ToListAsync(cancellationToken);
        return new OrderList { Orders = orders };
    }
}