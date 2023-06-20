using Application.Exceptions;
using Infrastructure.Persistance;
using Infrastructure.Repositories.Product;
using MediatR;

namespace Application.Product.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductEntity>
{

    private readonly ProductRepository _repository;

    public GetProductQueryHandler(ProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductEntity> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = _repository.GetEntityByIdAsync(request.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(ProductEntity), request.Id);
        }
        return new ProductEntity { Product = product};
    }
    
}