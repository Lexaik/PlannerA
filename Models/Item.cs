using System.Collections.Generic;
namespace PlannerA.Models;
public class Item (string name)
{
    public string name { get; set; } = name;
    public Dictionary<Item, int> subItems { get; set;} = [];
    public List<Operation> process { get; set; } = [];
    public void addSubItems(Item item, int quantity)
    {
        subItems[item] = quantity;
    }
    public void addProcess(Operation operation)
    {
        process.Add(operation);
    }
}