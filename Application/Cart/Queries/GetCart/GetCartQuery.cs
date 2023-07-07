namespace Application.Cart.Queries.GetCart;

public class GetCartQuery : IRequest<Domain.Entities.Cart>
{
    public Guid CartId { get; set; }
}