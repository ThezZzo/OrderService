using Domain.Entities;

namespace Domain.Test;

public class FakeData
{
    public Product FakeProduct(Price price, string name)
    {
        return Product.Create(price, name);
    }

    public Price FakePrice(long value)
    {
        return new Price { Value = value };
    }
    
    
}