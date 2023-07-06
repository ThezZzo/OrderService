namespace Application.Cart.Commands.Create;

public class CreateCartCommands : IRequest<Domain.Entities.Cart>
{
    public IList<OrderItem> OrderItems { get; set; }
}