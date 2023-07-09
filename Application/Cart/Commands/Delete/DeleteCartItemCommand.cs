namespace Application.Cart.Commands.Delete;

public class DeleteCartItemCommand : IRequest<bool>
{
    public string CartId { get; set; }
    
    public int ProductId { get; set; }
}