using System.Collections.Generic;

namespace PlannerA.Models;

public class Worker
{
    public string Name { get; init; }
    public string Type { get; init; }
    public List <Operation> Loading;

    public Worker(string name, string type)
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