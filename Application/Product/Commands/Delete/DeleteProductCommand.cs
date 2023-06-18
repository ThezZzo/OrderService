using MediatR;

namespace Application.Product.Commands.Delete;

public class DeleteProductCommand : IRequest<int>
{
    public int Id { get; }
}