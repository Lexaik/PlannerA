using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class ProcessService : ICrudService<Process>
{
    private readonly ICrud<Process> _crud;

    public ProcessService()
    {
        _crud = new ProcessDbContext();
    }
    
    public async Task<bool> InsertAsync(Process instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Process instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Process instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Process>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}