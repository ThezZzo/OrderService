using Domain.Common.Repository;
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
        return await _repository.GetAllAsync(cancellationToken);
    }
}