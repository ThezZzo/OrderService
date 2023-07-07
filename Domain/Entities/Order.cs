namespace Domain.Entities;

public class Order 
{
    public int Id { get; protected set; }
    
    public Cart Cart { get; init; }
    public SumPrice SumPrice { get; init; }

    public static Order Create(Cart cart, SumPrice sumPrice)
    {
        return new Order { Cart = cart, SumPrice = sumPrice };
    }
    
   
}



