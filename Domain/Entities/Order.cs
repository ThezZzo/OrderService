namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int ProductId { get; set; }
    public IEnumerable<Product> Product { get; set; }
    
    public int Count { get; set; }
    
}