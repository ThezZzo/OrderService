using Domain.Common.Repository;
using MediatR;

namespace Application.Product.Commands.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{

    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
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