using MediatR;

namespace Application.Order.Commands.Create;

public class CreateOrderCommand : IRequest<Domain.Entities.Order>
{
    public int ProductId { get; set; }
    public int Count { get; set; }
}