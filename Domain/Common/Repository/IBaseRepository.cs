using MediatR;

namespace Domain.Common.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<bool> RemoveEntityAsync(TEntity entity, int id, CancellationToken cancellationToken = default);

    Task<Unit> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEntity> GetEntityByIdAsync(int id,  CancellationToken cancellationToken = default);
}