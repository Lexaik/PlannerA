using System.Collections.Generic;

namespace PlannerA.Models;

public class Machinery
{
    public string Name { get; set; }
    public string Type { get; set; }
    public List <Operation> Loading;
    
    public Machinery(string name, string type)
    {
        this.Name = name;
        this.Type = type;
        Loading = new List<Operation>();
    }
    
    public void AddOperation(Operation operation)
    {
        Loading.Add(operation);
    }
}

