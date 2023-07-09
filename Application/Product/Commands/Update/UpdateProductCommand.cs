namespace Application.Product.Commands.Update;

public class UpdateProductCommand : IRequest<Domain.Entities.Product>
{
    public int ProductId { get; set; }
    public string Name { get; init; }
    public long Price { get; init; }
}