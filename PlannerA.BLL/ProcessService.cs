using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class ProcessService : ICrudService<Process>
{
    private readonly IProcessRepository _processRepository;

    public ProcessService(IProcessRepository processRepository)
    {
        _processRepository = processRepository;
    }
    
    public async Task<bool> InsertAsync(Process instance)
    {
        return await _processRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Process instance)
    {
        return await _processRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Process instance)
    {
        instance.is_active = false;
        return await _processRepository.UpdateAsync(instance);
    }

    public Task<IEnumerable<Process>> GetAllAsync()
    {
        return _processRepository.GetAllAsync(); 
    }
}