using PlannerA.Model;

namespace PlannerA.DAL;

public interface ICrud<T> where T : class
{
    public Task<bool> InsertAsync(T entity);
    public Task<bool> UpdateAsync(T entity);
    public Task<IEnumerable<T>> GetAllAsync();
    
}