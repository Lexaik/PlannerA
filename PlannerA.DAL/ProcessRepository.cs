using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IProcessRepository : ICrud<Process>
{
    Task<IEnumerable<Process>> GetActiveProcessAsync();
}

public class ProcessRepository : Repository<Process>, IProcessRepository
{
    public ProcessRepository() : base() { }

    public async Task<IEnumerable<Process>> GetActiveProcessAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}