using PlannerA.DAL;
using PlannerA.Model;

namespace PlannerA.BLL;

public class Service : ICrudService
{
    private readonly ICrud _crud;

    public Service()
    {
        _crud = new DBContext();
    }
    
    public bool Insert(Item item)
    {
        return _crud.Insert(item);
    }

    public bool Update(Item item)
    {
        return _crud.Update(item);
    }

    public bool Delete(Item item)
    {
        item.is_active = true;
        return _crud.Update(item);
    }

    public IEnumerable<Item> GetAll()
    {
        return _crud.GetAll(); 
    }
}