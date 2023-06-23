using Domain.Common.Repository;
using MediatR;

namespace Application.Product.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Domain.Entities.Product>
{

    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<Domain.Entities.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Price = request.Price
        };
        await _repository.AddEntityAsync(product, cancellationToken);
        return product;
    }
}   