using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace PlannerA.DAL;

public class Repository<T> : ICrud<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository()
    {
        _context = new DbContext();
        _dbSet = new DbContext().Set<T>();
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()=> await _dbSet.ToListAsync();

    public async Task<bool> InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}