using Domain.Common.Repository;
using Infrastructure.Repositories.Product;
using MediatR;

namespace Application.Product.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Domain.Entities.Product>
{

    private readonly IProductRepository _repository;

    public GetProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Domain.Entities.Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetEntityByIdAsync(request.Id, cancellationToken);
        return product;
    }
    
}