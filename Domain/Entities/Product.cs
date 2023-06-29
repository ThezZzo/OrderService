using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Product
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public decimal Price { get; set; }

    [NotMapped]
    public IEnumerable<Order> Orders { get; set; } = null!;
}