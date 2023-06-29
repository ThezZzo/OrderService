using Domain.Common.Repository;
using Domain.Exceptions;
using MediatR;

namespace Application.Product.Queries.AllProducts;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Domain.Entities.Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(cancellationToken);
        if (result == null)
        {
            throw new NotFoundListException(nameof(result));
        }
        return result;
    }
}