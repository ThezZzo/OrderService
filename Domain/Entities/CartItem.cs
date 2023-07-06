namespace Domain.Entities;

public class CartItem
{
    public int Id { get; init; }

    private Product Product { get; init; }

    private Quantity Quantity { get; init; }

    private DateTime DateCreated { get; init; }

    public CartItem Create(Product product, Quantity quantity, DateTime dateTime)
    {
        return new CartItem { Product = product, Quantity = quantity, DateCreated = dateTime};
    }
    
}