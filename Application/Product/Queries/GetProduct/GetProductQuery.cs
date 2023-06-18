using MediatR;

namespace Application.Product.Queries.GetProduct;

public class GetProductQuery : IRequest<ProductEntity>
{
    public int Id { get; set; }
}