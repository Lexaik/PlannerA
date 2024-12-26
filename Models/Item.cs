using System.Collections.Generic;

namespace PlannerA.Models;

public class Item
{
    public string name { get; set; }
    public Dictionary<Item, int> sub_items;
    public List<Operation> process { get; set; }
}