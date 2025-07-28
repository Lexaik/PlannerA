using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class PersonService : ICrudService<Person>
{
    private readonly IPersonRepository _personRepository;

    public PersonService()
    {
        _personRepository = new PersonRepository();
    }

    /*public PersonService()
    {
        throw new NotImplementedException();
    }*/

    public async Task<bool> InsertAsync(Person instance)
    {
        return await _personRepository.InsertAsync(instance);
    }

    public async Task<bool> UpdateAsync(Person instance)
    {
        return await _personRepository.UpdateAsync(instance);
    }

    public async Task<bool> DeleteAsync(Person instance)
    {
        instance.is_active = false;
        return await _personRepository.UpdateAsync(instance);
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        return await _personRepository.GetAllAsync(); 
    }
}