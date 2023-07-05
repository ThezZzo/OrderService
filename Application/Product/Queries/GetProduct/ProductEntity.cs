namespace Application.Product.Queries.GetProduct;

public class ProductEntity
{
    public Task<Domain.Entities.Product> Product { get; set; }
}