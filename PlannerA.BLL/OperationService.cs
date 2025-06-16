using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class OperationService : ICrudService<Operation>
{
    private readonly ICrud<Operation> _crud;

    public OperationService()
    {
        _crud = new OperationDbContext();
    }
    
    public async Task<bool> InsertAsync(Operation instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Operation instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Operation instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Operation>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}