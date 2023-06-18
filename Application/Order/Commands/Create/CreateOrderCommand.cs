using Application.Product.Queries.GetProduct;
using MediatR;

namespace Application.Order.Commands.Create;

public class CreateOrderCommand : IRequest<Unit>
{
    public int ProductId { get; set; }
    public int Count { get; set; }
}