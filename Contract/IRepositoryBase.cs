using System.Linq.Expressions;

namespace Contract;

public interface IRepositoryBase<T>
{
    Task AddAsync(T entity);
    Task Update(T entity);
    Task Remove(T entity);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
}