using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IItemRepository : ICrud<Item>
{
    Task<IEnumerable<Item>> GetActiveItemAsync();
}

public class ItemRepository : Repository<Item>, IItemRepository
{
    public ItemRepository() : base() { }

    public async Task<IEnumerable<Item>> GetActiveItemAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}