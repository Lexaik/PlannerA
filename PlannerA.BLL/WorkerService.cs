using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class WorkerService : ICrudService<Worker>
{
    private readonly ICrud<Worker> _crud;

    public WorkerService()
    {
        _crud = new WorkerDbContext();
    }
    
    public async Task<bool> InsertAsync(Worker instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Worker instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Worker instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Worker>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}