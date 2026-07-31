using CleanArchitecture.Contracts;
using CleanArchitecture.Contracts.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure;

public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
    where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException();
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<PagedResponseBase<TEntity>> GetPagedAsync(PagedRequestBase request, CancellationToken cancellationToken)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();
        var totalItems = await query.CountAsync(cancellationToken);
        var data = await query
            .Skip((request.CurrentPage - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        return new PagedResponseBase<TEntity>(
            data,
            request.CurrentPage,
            request.PageSize,
            totalItems);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync([id], cancellationToken);
        return entity;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public virtual TEntity Update(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public virtual void Delete(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
    }
}