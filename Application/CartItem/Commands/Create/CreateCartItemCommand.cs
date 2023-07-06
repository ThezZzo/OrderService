namespace Application.CartItem.Commands.Create;

public class CreateCartItemCommand : IRequest<Domain.Entities.CartItem>
{
    public int CartId { get; set; }
    public int productId { get; set; }
    public long Quantity { get; set; }
}