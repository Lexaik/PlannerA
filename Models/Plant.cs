using System.Collections.Generic;

namespace PlannerA.Models;

public class Plant
{
    public string name { get; set; }
    public List<Employee> employees { get; set; }
    public List<Inventories> inventories { get; set; }
    public List<Machinery> machinery { get; set; }
    
}