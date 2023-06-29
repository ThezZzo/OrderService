using Domain.Common.DTOs;
using MediatR;

namespace Application.Order.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<IEnumerable<Domain.Entities.Order>>
{

}