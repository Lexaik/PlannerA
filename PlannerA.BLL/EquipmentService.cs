using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class EquipmentService : ICrudService<Equipment>
{
    private readonly IEquipmentRepository _equipmentRepository;

    public EquipmentService()
    {
        _equipmentRepository = new EquipmentRepository();
    }

    /*public EquipmentService()
    {
        throw new NotImplementedException();
    }*/

    public async Task<bool> InsertAsync(Equipment instance)
    {
        return await _equipmentRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Equipment instance)
    {
        return await _equipmentRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Equipment instance)
    {
        instance.is_active = false;
        return await _equipmentRepository.UpdateAsync(instance);
    }

    public Task<IEnumerable<Equipment>> GetAllAsync()
    {
        return _equipmentRepository.GetAllAsync(); 
    }
}