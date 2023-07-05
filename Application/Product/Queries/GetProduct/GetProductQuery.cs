namespace Application.Product.Queries.GetProduct;

public class GetProductQuery : IRequest<Domain.Entities.Product>
{
    public int Id { get; set; }
}