using PlannerA.Model;

namespace PlannerA.BLL;

public interface ICrudService<T> where T : class
{
    public Task<bool> InsertAsync(T entity);
    public Task<bool> UpdateAsync(T entity);
    public Task<bool> DeleteAsync(T entity);
    public Task<IEnumerable<T>> GetAllAsync();
}