using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Product  
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public Price Price { get; set; }

    [NotMapped]
    public IEnumerable<Order> Orders { get; set; } = null!;

    public static Product Create(Price price, string name)
    {
        var str = name.Trim();
        if (str.Length is > 20 or < 1)
        {
            throw new Exception("Must be more 0");
        }

        return new Product { Price = price, Name = str };
    }
    
    public Product(){}
}

public class Price
{
    public long Value { get; init; }

    public static Price Create(long value)
    {
        if (value < 0)
        {
            throw new Exception("Must be more 0");
        }

        return new Price { Value = value};
    }
}