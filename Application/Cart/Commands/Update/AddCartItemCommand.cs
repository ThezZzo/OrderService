namespace Application.Cart.Commands.Update;

public class AddCartItemCommand : IRequest<Domain.Entities.Cart>
{
    public Guid CartId { get; set; }
    
    public Domain.Entities.Product Product { get; set; }
    
    public long Quantity { get; set; }
}