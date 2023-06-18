using Application.Exceptions;
using Application.Product.Commands.Update;
using Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Commands.Update;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly ApplicationDbContext _dbContext;

    public UpdateOrderCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (order == null || order.Id != request.Id)
        {
            throw new NotFoundException(nameof(order), request.Id);
        }
        order.Result.Count = request.Count;
        order.Result.ProductId = request.ProductId;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}