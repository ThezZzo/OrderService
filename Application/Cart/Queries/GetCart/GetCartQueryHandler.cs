﻿using Domain.Common.DTO;

namespace Application.Cart.Queries.GetCart;

public class GetCartCommandHandler : IRequestHandler<GetCartQuery, IEnumerable<CartItemDTO>>
{
    private readonly ICartRepository _cartRepository;

    public GetCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
     
    public async Task<IEnumerable<CartItemDTO>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        return await _cartRepository.GetCartItems(request.CartId, cancellationToken);
    }
}