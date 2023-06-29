using Domain.Exceptions;
using Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Product.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly ApplicationDbContext _dbContext;

    public UpdateProductCommandHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null || product.Id != request.Id)
        {
            throw new NotFoundException(nameof(product), request.Id);
        }
        product.Result.Name = request.Name;
        product.Result.Price = request.Price;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}