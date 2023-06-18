using MediatR;

namespace Application.Order.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<OrderList>
{
    public int Id { get; set; }
}