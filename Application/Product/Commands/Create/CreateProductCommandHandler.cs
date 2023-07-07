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
        var entity = Domain.Entities.Product.Create(Price.Create(request.Price), request.Name);
        await _repository.AddEntityAsync(entity, cancellationToken);
        return entity;
    }
}   