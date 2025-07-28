using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class ItemService : ICrudService<Item>
{
    private readonly IItemRepository _itemRepository;

    public ItemService()
    {
        _itemRepository = new ItemRepository();
    }

    /*public ItemService()
    {
        throw new NotImplementedException();
    }*/

    public async Task<bool> InsertAsync(Item instance)
    {
        return await _itemRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Item instance)
    {
        return await _itemRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Item instance)
    {
        instance.is_active = false;
        return await _itemRepository.UpdateAsync(instance);
    }

    public Task<IEnumerable<Item>> GetAllAsync()
    {
        return _itemRepository.GetAllAsync(); 
    }
}