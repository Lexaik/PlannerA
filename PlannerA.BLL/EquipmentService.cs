using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class EquipmentService : ICrudService<Equipment>
{
    private readonly ICrud<Equipment> _crud;

    public EquipmentService()
    {
        _crud = new EquipmentDbContext();
    }
    
    public async Task<bool> InsertAsync(Equipment instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Equipment instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Equipment instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Equipment>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}