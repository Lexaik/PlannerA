using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IOrderRepository : ICrud<Order>
{
    Task<IEnumerable<Order>> GetActiveOrderAsync();
}

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository() : base() { } 

    public async Task<IEnumerable<Order>> GetActiveOrderAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}