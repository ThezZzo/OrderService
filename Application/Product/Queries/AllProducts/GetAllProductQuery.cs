using MediatR;

namespace Application.Product.Queries.AllProducts;

public class GetAllProductQuery : IRequest<ProductList>
{
    public int Id { get; set; }
}