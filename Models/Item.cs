using System.Collections.Generic;

namespace PlannerA.Models;

public class Item
{
    public string name { get; set; }
    public Dictionary<Item, int> sub_items;
    public List<Operation> process { get; set; }

    public Item(string name)
    {
     this.name = name;
     sub_items = new Dictionary<Item, int>();
     process = new List<Operation>();
    }
    public void addSubItems(Item item, int quantity)
    {
        sub_items[item] = quantity;
    }

    public void addProcess(Operation operation)
    {
        process.Add(operation);
    }
}