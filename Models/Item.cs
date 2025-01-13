using System.Collections.Generic;

namespace PlannerA.Models;

public class Item
{
    public string Name { get; set; }
    public Dictionary<Item, int> SubItems;
    public List<Operation> Process { get; set; }

    public Item(string name)
    {
        Name = name;
        SubItems = new Dictionary<Item, int>();
        Process = new List<Operation>();
    }
    
    

    public void AddSubItems(Item item, int quantity)
    {
        SubItems[item] = quantity;
    }

    public void AddProcess(Operation operation)
    {
        Process.Add(operation);
    }
}