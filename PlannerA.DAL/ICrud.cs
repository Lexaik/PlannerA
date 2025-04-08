using PlannerA.Model;

namespace PlannerA.DAL;

public interface ICrud
{
    public bool Insert(Item item);
    public bool Update(Item item);
    public IEnumerable<Item> GetAll();
}