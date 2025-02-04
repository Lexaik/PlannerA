using System.Collections.Generic;

namespace PlannerA.Models;

public class Worker
{
    public List<Operation> Loading;
    public Worker(string name, string type)
    {
        Name = name;
        Type = type;
        Loading = new List<Operation>();
    }
    public string Name { get; init; }
    public string Type { get; init; }
    public void AddOperation(Operation operation)
    {
        Loading.Add(operation);
    }
}