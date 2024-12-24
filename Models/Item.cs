using System.Collections.Generic;

namespace PlannerA.Models;

public class Item
{
    public string ItemName { get; set; }
    public List<Item> SubItems { get; set; }
    public List<Operation> Operations { get; set; }
}