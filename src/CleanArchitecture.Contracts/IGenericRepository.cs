using CleanArchitecture.Contracts.DataTransferObjects;

namespace CleanArchitecture.Contracts;

public interface IGenericRepository<TEntity, TId>
{
    Task<PagedResponseBase<TEntity>> GetPagedAsync(PagedRequestBase request, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    TEntity Update(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity entity, CancellationToken cancellationToken);
}