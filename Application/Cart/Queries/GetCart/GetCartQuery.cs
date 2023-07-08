using Domain.Common.DTO;

namespace Application.Cart.Queries.GetCart;

public class GetCartQuery : IRequest<IEnumerable<CartItemDTO>>
{
    public Guid CartId { get; set; }
}