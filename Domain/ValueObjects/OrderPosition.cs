using Domain.Entities;

namespace Domain.ValueObjects;

public class OrderPosition
{
    private Product Product { get; init; }
    
    private Quantity Quantity { get; init; }

    public static OrderPosition Create(Product product, Quantity quantity)
    {
        return new OrderPosition { Product = product, Quantity = quantity };
    }
}