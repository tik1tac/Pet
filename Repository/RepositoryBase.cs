using System.Linq.Expressions;

using Contract;

using Microsoft.EntityFrameworkCore;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly AplicationContext context;

    public RepositoryBase(AplicationContext _context) => this.context = _context;
    public async Task AddAsync(T entity) => await context.Set<T>().AddAsync(entity);

    public async Task Update(T entity) => await Task.FromResult(context.Set<T>().Update(entity));

    public async Task Remove(T entity) => await Task.FromResult(context.Set<T>().Remove(entity));

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default) => await
        Task.FromResult(await context.Set<T>().AsNoTracking().ToListAsync(cancellationToken));

    public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default) => await
        Task.FromResult(await context.Set<T>().Where(expression).ToListAsync(cancellationToken));
}