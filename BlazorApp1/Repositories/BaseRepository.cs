using System.Linq.Expressions;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{

    private readonly ApplicationDbContext _context;
    
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(TEntity model)
    {
        await _context.Set<TEntity>().AddAsync(model);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> models)
    {
        await _context.Set<TEntity>().AddRangeAsync(models);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<TEntity>().CountAsync();
    }

    public async Task UpdateAsync(TEntity objModel)
    {
        _context.Entry(objModel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(TEntity objModel)
    {
        _context.Set<TEntity>().Remove(objModel);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
