namespace Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public Product Product { get; init; }
    
    public Quantity Quantity { get; init; }

    public static OrderItem Create(Product product, Quantity quantity)
    {
        return new OrderItem { Product = product, Quantity = quantity };
    }
}