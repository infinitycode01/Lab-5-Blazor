using System.Linq.Expressions;

namespace BlazorApp1.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity model);
    Task AddRangeAsync(IEnumerable<TEntity> models);
    Task<TEntity?> GetIdAsync(int id);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<int> CountAsync();
    Task UpdateAsync(TEntity objModel);
    Task RemoveAsync(TEntity objModel);
    Task DisposeAsync();
}
