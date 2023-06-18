using MediatR;

namespace Application.Product.Commands.Delete;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; }
}