using MediatR;

namespace Application.Order.Commands.Update;

public class UpdateOrderCommand : IRequest<Unit>
{
    public int Count { get; set; }
    public int ProductId { get; set; }
    public int Id { get; set; }
}