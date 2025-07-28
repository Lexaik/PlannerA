using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class WorkerService : ICrudService<Worker>
{
    private readonly IWorkerRepository _workerRepository;

    public WorkerService()
    {
        _workerRepository = new WorkerRepository();
    }

    /*public WorkerService()
    {
        throw new NotImplementedException();
    }*/

    public async Task<bool> InsertAsync(Worker instance)
    {
        return await _workerRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Worker instance)
    {
        return await _workerRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Worker instance)
    {
        instance.is_active = false;
        return await _workerRepository.UpdateAsync(instance);
    }

    public Task<IEnumerable<Worker>> GetAllAsync()
    {
        return _workerRepository.GetAllAsync(); 
    }
}