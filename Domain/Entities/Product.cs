namespace Domain.Entities;

public class Product  
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public Price Price { get; set; }
    
    public static Product Create(Price price, string name)
    {
        var str = name.Trim();
        if (str.Length is > 20 or < 1)
        {
            throw new Exception("Must be in range 1 and 20");
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