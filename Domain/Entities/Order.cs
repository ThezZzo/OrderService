using System.ComponentModel;
using Domain.ValueObjects;

namespace Domain.Entities;

[DisplayName]
public class Order 
{
    public int Id { get; protected set; }
    
    public IList<OrderPosition> OrderPositions { get; init; } 
    
    public SumPrice SumPrice { get; init; }

    private static Order Create(IList<OrderPosition> orderPositions, SumPrice sumPrice)
    {
        
        return new Order { OrderPositions = orderPositions, SumPrice = sumPrice };
    }
}



