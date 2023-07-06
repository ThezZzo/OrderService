namespace Domain.Entities;

public class Order 
{
    public int Id { get; protected set; }
    
    public Cart Cart { get; init; }
    public List<OrderItem> OrderItems { get;  init; }
    public SumPrice SumPrice { get; init; }

    public static Order Create(List<OrderItem> orderItems, SumPrice sumPrice)
    {
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
        return orderItems.Sum(item => item.Quantity.Value * item.Product.Price.Value);
    }
}



