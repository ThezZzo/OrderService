
using Infrastructure.Repositories.Product;
using MediatR;


namespace Application.Product.Queries.AllProducts;

public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Domain.Entities.Product>>
{
    private readonly ProductRepository _repository;

    public GetAllProductQueryHandler(ProductRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Domain.Entities.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
    }
}