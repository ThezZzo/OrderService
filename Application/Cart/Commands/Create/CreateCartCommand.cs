namespace Application.Cart.Commands.Create;

public class CreateCartCommand : IRequest<Domain.Entities.Cart>
{

    public Domain.Entities.Product Product { get; set; }
    public long Quantity { get; set; }

}