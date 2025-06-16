using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class DepartmentService : ICrudService<Department>
{
    private readonly ICrud<Department> _crud;

    public DepartmentService()
    {
        _crud = new DepartmentDbContext();
    }
    
    public async Task<bool> InsertAsync(Department instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Department instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Department instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Department>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}