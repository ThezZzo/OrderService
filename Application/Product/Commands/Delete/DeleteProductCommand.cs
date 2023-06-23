using MediatR;

namespace Application.Product.Commands.Delete;

public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }
    public Domain.Entities.Product Product { get; set; }
}