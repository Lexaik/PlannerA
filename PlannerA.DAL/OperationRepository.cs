using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IOperationRepository : ICrud<Operation>
{
    Task<IEnumerable<Operation>> GetActiveOperationAsync();
}

public class OperationRepository : Repository<Operation>, IOperationRepository
{
    public OperationRepository() : base() { }

    public async Task<IEnumerable<Operation>> GetActiveOperationAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}