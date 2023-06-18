using MediatR;

namespace Application.Order.Commands.Delete;

public class DeleteOrderCommand : IRequest<Unit>
{
    public int OrderId { get; set; }
}