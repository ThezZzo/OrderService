using System.ComponentModel;

namespace Domain.Entities;

[DisplayName]
public class Order 
{
    public int Id { get; protected set; }
    
    public IList<OrderItem> OrderItems { get; init; } 
    
    public SumPrice SumPrice { get; init; }

    public static Order Create(IList<OrderItem> orderItems, SumPrice sumPrice)
    {
        if (!orderItems.Any())
        {
            throw new Exception();
        }
        return new Order { OrderItems = orderItems, SumPrice = sumPrice };
    }

    public void AddOrderItem(Product product, Quantity quantity)
    {
        if (product.Equals(null) || quantity.Equals(null))
        {
            throw new Exception();
        }
        var orderItem = OrderItem.Create(product, quantity);
        OrderItems.Add(orderItem);
    }

    public static long CalculateFinalPrice(IList<OrderItem> orderItems)
    {
        if (!orderItems.Any())
        {
            throw new Exception();
        }

        long price = 0;
        
        foreach (var item in orderItems)
        {
            price += item.Quantity.Value * item.Product.Price.Value;
        }
        
        return price;
    }
}



