using Application.Exceptions;
using Infrastructure.Persistance;
using MediatR;

namespace Application.Product.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductEntity>
{
    private readonly ApplicationDbContext _dbContext;

    public GetProductQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductEntity> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.FindAsync(request.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(ProductEntity), request.Id);
        }
        return new ProductEntity { Product = product};
    }
    
}