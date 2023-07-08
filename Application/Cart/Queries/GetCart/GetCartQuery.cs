namespace Application.Cart.Queries.GetCart;

public class GetCartQuery : IRequest<List<Domain.Entities.Cart>>
{
    public Guid CartId { get; set; }
}