using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class ClientService : ICrudService<Client>
{
    private readonly ICrud<Client> _crud;

    public ClientService()
    {
        _crud = new ClientDbContext();
    }
    
    public async Task<bool> InsertAsync(Client instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Client instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Client instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }
    
    public Task<IEnumerable<Client>> GetAllAsync()
    {
        return _crud.GetAllAsync();
    }
}