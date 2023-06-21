using MediatR;

namespace Application.Order.Commands.Delete;

public class DeleteOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
}