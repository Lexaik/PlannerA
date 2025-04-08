using System;
using System.Collections.Generic;
namespace PlannerA.Models;
public class Item (string name)
{
    public string name { get; set; } = name;
    public DateTime date_entering { get; set; }
    public Dictionary<Item, int> subItems { get; set;} = [];
    public List<Operation> operations { get; set; } = [];
    public void addSubItems(Item item, int quantity)
    {
        subItems[item] = quantity;
    }
    public void addOperation(Operation x)
    {
        operations.Add(x);
    }
}