using PlannerA.Model;

namespace PlannerA.DAL;

public interface ICrud<T> where T : class
{
    public Task<bool> InsertAsync(T instance);
    public Task<bool> UpdateAsync(T instance);
    public Task<IEnumerable<T>> GetAllAsync();
}