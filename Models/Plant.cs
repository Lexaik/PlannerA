using System.Collections.Generic;

namespace PlannerA.Models;

public class Plant
{
    public string name { get; set; }
    public List<Worker> employee;
    public Dictionary<Item, int> inventories;
    public List<Machinery> equipment;
    public List<Order> orders;
    
}