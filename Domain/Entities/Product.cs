using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal Price { get; set; }

    [NotMapped]
    public IEnumerable<Order> Orders { get; set; } = null!;

    private Product(string _Name, decimal _Price)
    {
        Name = _Name;
        Price = _Price;
    }
    
    public Product(){}
}