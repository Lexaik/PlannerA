using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class OrderService : ICrudService<Order>
{
    private readonly ICrud<Order> _crud;

    public OrderService()
    {
        _crud = new OrderDbContext();
    }
    
    public async Task<bool> InsertAsync(Order instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Order instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Order instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}