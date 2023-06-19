
using Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common.Repository;

public class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    
    public BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> RemoveAsync(TEntity entity, int id, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<Unit> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var list = await _dbSet.ToListAsync(cancellationToken);
        return list;
    }

    public async Task<TEntity> GetEntityByIdAsync(TEntity entity, int id, CancellationToken cancellationToken = default)
    {
        var result = await _dbSet.FindAsync(entity);
        if (result == null)
        {
            throw new NotFoundException(nameof(entity), id);
        }
        return result;
    }
}