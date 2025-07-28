using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IWorkerRepository : ICrud<Worker>
{
    Task<IEnumerable<Worker>> GetActiveWorkerAsync();
}

public class WorkerRepository : Repository<Worker>, IWorkerRepository
{
    public WorkerRepository() : base() { }

    public async Task<IEnumerable<Worker>> GetActiveWorkerAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}