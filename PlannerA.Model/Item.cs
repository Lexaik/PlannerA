namespace PlannerA.Model;

public class Item
{
    public string name { get; set; }
    public DateTime? date_of_produce { get; set; }
    public string? parameters { get; set; }
    public double? price { get; set; }
    public bool is_active { get; set; } = true;    
    public Dictionary<Item, int> subItems { get; set;}
    public List<Operation> operations { get; set; }
    
    public void addSubItems(Item item, int quantity)
    {
        subItems[item] = quantity;
    }
    public void addOperation(Operation x)
    {
        operations.Add(x);
    }
}