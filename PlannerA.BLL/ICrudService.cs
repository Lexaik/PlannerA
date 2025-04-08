using PlannerA.Model;

namespace PlannerA.BLL;

public interface ICrudService
{
    public bool Insert(Item item);
    public bool Update(Item item);
    public bool Delete(Item item);
    public IEnumerable<Item> GetAll();
}