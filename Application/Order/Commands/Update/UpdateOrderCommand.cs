
namespace Application.Order.Commands.Update;

public class UpdateOrderCommand : IRequest<Domain.Entities.Product>
{
    public long Price { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
}