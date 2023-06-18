using MediatR;

namespace Application.Product.Commands.Update;

public class UpdateProductCommand : IRequest, IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}