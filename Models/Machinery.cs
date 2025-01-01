using System.Collections.Generic;

namespace PlannerA.Models;

public class Machinery
{
    public string name { get; set; }
    public string type { get; set; }
    public List <Operation> loading;
    
    public Machinery(string name, string type)
    {
        this.name = name;
        this.type = type;
        loading = new List<Operation>();
    }
    
    public void AddOperation(Operation operation)
    {
        loading.Add(operation);
    }
}

