using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IClientRepository : ICrud<Client>
{
    Task<IEnumerable<Client>> GetActiveClientAsync();
}

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository() : base() { }

    public async Task<IEnumerable<Client>> GetActiveClientAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}