using Microsoft.EntityFrameworkCore;

namespace Domain.Common.Repository;

public class BaseRepository<TEntity, TDbContext> : IBaseRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    
    protected BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> AddEntityAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);   
        return entity;
    }
    
    public async Task<bool> RemoveEntityAsync(TEntity entity, int id, CancellationToken cancellationToken)
    {
        var result = await _dbSet.FindAsync(id);
        if (result == null)
        {
            throw new Exception();
        }
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var list = await _dbSet.ToListAsync(cancellationToken);
        if (!list.Any())
        {
            throw new Exception();
        }
        return list;
    }

    public async Task<TEntity> GetEntityByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await _dbSet.FindAsync(id);
        if (result == null)
        {
            throw new Exception();
        }
        return result;
    }
    
    public async Task<IList<TEntity>> AddListEntityAsync(IList<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }
}