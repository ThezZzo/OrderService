namespace Application.Product.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Domain.Entities.Product>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<Domain.Entities.Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entityForUpdate = await _productRepository.GetEntityByIdAsync(request.ProductId, cancellationToken);
        
        if (entityForUpdate == null)
        {
            throw new Exception();
        }

        entityForUpdate.Name = request.Name;
        entityForUpdate.Price = Price.Create(request.Price);
        return await _productRepository.UpdateEntityAsync(entityForUpdate, cancellationToken);
    }
}