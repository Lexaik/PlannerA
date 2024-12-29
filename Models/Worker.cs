using System.Collections.Generic;

namespace PlannerA.Models;

public class Worker
{
    public string name { get; init; }
    public string type { get; init; }
    public List <Operation>? loading;

    public Worker(string name, string type)
    {
        this.name = name;
        this.type = type;
        loading = new List<Operation>();
    }
    
    public void addOperation(Operation operation)
    {
        loading.Add(operation);
    }
}