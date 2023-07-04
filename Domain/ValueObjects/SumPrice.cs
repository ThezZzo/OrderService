using Domain.Entities;

namespace Domain.ValueObjects;

public class SumPrice
{
    private long Value { get; set; }

    public static SumPrice Create(Product product, long value)
    {
        if (value < 0)
        {
            throw new Exception();
        }
        var result = product.Price.Value * value;
        return new SumPrice { Value = result };
    }
}