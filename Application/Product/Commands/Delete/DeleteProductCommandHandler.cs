using Domain.Common.Repository;

using MediatR;

namespace Application.Product.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _repository.RemoveEntityAsync(request.Product, request.Id, cancellationToken);
    }
}