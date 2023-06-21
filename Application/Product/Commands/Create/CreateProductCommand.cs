using MediatR;

namespace Application.Product.Commands.Create;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}