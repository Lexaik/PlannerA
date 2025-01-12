using System.Collections.Generic;

namespace PlannerA.Models;

public class Machinery
{
    public List<Operation> Loading;

    public Machinery(string name, string type)
    {
        Name = name;
        Type = type;
        Loading = new List<Operation>();
    }

    public string Name { get; set; }
    public string Type { get; set; }

    public void AddOperation(Operation operation)
    {
        Loading.Add(operation);
    }
}