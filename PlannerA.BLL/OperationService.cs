using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class OperationService : ICrudService<Operation>
{
    private readonly IOperationRepository _operationRepository;

    public OperationService()
    {
        _operationRepository = new OperationRepository();
    }

    /*public OperationService()
    {
        throw new NotImplementedException();
    }*/

    public async Task<bool> InsertAsync(Operation instance)
    {
        return await _operationRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Operation instance)
    {
        return await _operationRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Operation instance)
    {
        instance.is_active = false;
        return await _operationRepository.UpdateAsync(instance);
    }

    public Task<IEnumerable<Operation>> GetAllAsync()
    {
        return _operationRepository.GetAllAsync(); 
    }
}