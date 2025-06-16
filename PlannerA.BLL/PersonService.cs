using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class PersonService : ICrudService<Person>
{
    private readonly ICrud<Person> _crud;

    public PersonService()
    {
        _crud = new PersonDbContext();
    }
    
    public async Task<bool> InsertAsync(Person instance)
    {
        return await _crud.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Person instance)
    {
        return await _crud.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Person instance)
    {
        instance.is_active = false;
        return await _crud.UpdateAsync(instance);
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _crud.GetAllAsync(); 
    }
}