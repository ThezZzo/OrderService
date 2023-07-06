namespace Domain.Entities;

public class CartItem
{
    public int Id { get; init; }

    public Product Product { get; init; }

    public Quantity Quantity { get; init; }

    public DateTime DateCreated { get; init; }

    public static CartItem Create(Product product, Quantity quantity)
    {
        return new CartItem { Product = product, Quantity = quantity, DateCreated = DateTime.UtcNow};
    }
    
}