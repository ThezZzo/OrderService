namespace Application.Product.Commands.Create;

public class CreateProductCommand : IRequest<Domain.Entities.Product>
{
    public string Name { get; set; }
    public long Price { get; set; }
}