using Application.Exceptions;
using Application.Product.Commands.Create;
using Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly ApplicationDbContext _dbContext;

    public DeleteProductCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.FindAsync(new object[]{request.Id}, cancellationToken);
        if (product == null || product.Result.Id != request.Id)
        {
            throw new NotFoundException(nameof(product), request.Id);
        }

        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}