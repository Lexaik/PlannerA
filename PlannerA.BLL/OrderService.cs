using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class OrderService : ICrudService<Order>
{
    private readonly IOrderRepository _orderRepository;

    public OrderService()
    {
        _orderRepository = new OrderRepository();
    }
    
    public async Task<bool> InsertAsync(Order instance)
    {
        return await _orderRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Order instance)
    {
        return await _orderRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Order instance)
    {
        instance.is_active = false;
        return await _orderRepository.UpdateAsync(instance);
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        return _orderRepository.GetAllAsync(); 
    }
}