using Domain.Entities;

namespace Domain.Common.DTOs;

public class OrderDTO
{
    public string Name { get; set; }
    
    public Product Product { get; set; }
    
    public int Count { get; set; }
}