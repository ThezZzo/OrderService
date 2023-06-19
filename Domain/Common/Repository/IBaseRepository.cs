using MediatR;

namespace Domain.Common;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<bool> RemoveAsync(TEntity entity, int id, CancellationToken cancellationToken = default);

    Task<Unit> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<TEntity> GetEntityByIdAsync(TEntity entity, int id,  CancellationToken cancellationToken = default);
}