namespace Application.Product.Commands.Create;

public class CreateProductCommand : IRequest<Domain.Entities.Product>
{
    public string Name { get; set; }
    public Price Price { get; set; }
}