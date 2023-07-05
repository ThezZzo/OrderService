namespace Application.Order.Commands.Create;

public class CreateOrderCommand : IRequest<Domain.Entities.Order>
{
    public IList<OrderItem> OrderItems { get; set; }
}