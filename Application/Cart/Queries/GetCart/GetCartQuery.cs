namespace Application.Cart.Queries.GetCart;

public class GetCartQuery : IRequest<IList<Domain.Entities.CartItem>>
{
    public Guid CartId { get; set; }
}