using Application.Exceptions;
using Application.Order.Commands.Create;
using Application.Product.Commands.Delete;
using Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Order.Commands.Delete;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly ApplicationDbContext _dbContext;
    
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var order = await _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (order == null)
        {
            throw new NotFoundException(nameof(order), request.Id);
        }
        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}