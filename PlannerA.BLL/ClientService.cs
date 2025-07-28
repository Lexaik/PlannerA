using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class ClientService : ICrudService<Client>
{
    private readonly IClientRepository _clientRepository;

    public ClientService()
    {
        _clientRepository = new ClientRepository();
    }

    /*public ClientService()
    {
        throw new NotImplementedException();
    }*/

    public async Task<bool> InsertAsync(Client instance)
    {
        return await _clientRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Client instance)
    {
        return await _clientRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Client instance)
    {
        instance.is_active = false;
        return await _clientRepository.UpdateAsync(instance);
    }
    
    public Task<IEnumerable<Client>> GetAllAsync()
    {
        return _clientRepository.GetAllAsync();
    }
}