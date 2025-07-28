using Microsoft.EntityFrameworkCore;
using PlannerA.Model;

namespace PlannerA.DAL;

public interface IPersonRepository : ICrud<Person>
{
    Task<IEnumerable<Person>> GetActivePersonAsync();
}

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository() : base() { }

    public async Task<IEnumerable<Person>> GetActivePersonAsync()
    {
        return await _dbSet.Where(o=>o.is_active).ToListAsync();
    }
}