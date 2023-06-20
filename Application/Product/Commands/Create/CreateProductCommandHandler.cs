using Infrastructure.Persistance;
using Infrastructure.Repositories.Product;
using MediatR;

namespace Application.Product.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{

    private readonly ProductRepository _repository;

    public CreateProductCommandHandler(ProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Domain.Entities.Product
        {
            Name = request.Name,
            Price = request.Price
        };
        await _repository.AddEntityAsync(product, cancellationToken);
        return product.Id;
    }
}