using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IEquipmentRepository : ICrud<Equipment>
{
    Task<IEnumerable<Equipment>> GetActiveEquipmentAsync();
}

public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository() : base() { }

    public async Task<IEnumerable<Equipment>> GetActiveEquipmentAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}