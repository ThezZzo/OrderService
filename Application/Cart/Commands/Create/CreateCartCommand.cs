﻿namespace Application.Cart.Commands.Create;

public class CreateCartCommand : IRequest<Domain.Entities.Cart>
{
    public Guid CartId { get; set; }
    public Domain.Entities.CartItem CartItem { get; set; }
}