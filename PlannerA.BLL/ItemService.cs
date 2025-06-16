using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class ItemService : ICrudService<Item>
{
    private readonly ICrud<Item> _crud;

    public ItemService()
    {
        _crud = new ItemDbContext();
    }
    
    public async Task<bool> InsertAsync(Item instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Item instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Item instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public Task<IEnumerable<Item>> GetAllAsync()
    {
        return _crud.GetAllAsync(); 
    }
}