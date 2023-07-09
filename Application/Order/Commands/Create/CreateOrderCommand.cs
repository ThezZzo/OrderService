namespace Application.Order.Commands.Create;

public class CreateOrderCommand : IRequest<Domain.Entities.Order>
{
    public string CartId { get; set; }

}