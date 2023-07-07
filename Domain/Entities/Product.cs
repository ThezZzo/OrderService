namespace Domain.Entities;

public class Product  
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Price Price { get; set; }
    
    public static Product Create(Price price, string name)
    {
        return new Product { Price = price, Name = name };
    }
    
    public Product(){}
}

