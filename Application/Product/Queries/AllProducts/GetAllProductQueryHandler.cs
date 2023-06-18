using Application.Product.Queries.GetProduct;
using Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Queries.AllProducts;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, ProductList>
{
    private readonly ApplicationDbContext _dbContext;

    public GetAllProductQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ProductList> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await _dbContext.Products.ToListAsync(cancellationToken);
        return new ProductList { Products = products };
    }
}