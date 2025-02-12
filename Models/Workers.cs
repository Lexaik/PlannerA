using System.Collections.Generic;
namespace PlannerA.Models;
public class Workers (string name, string type)
{
    public string name { get; init; } = name;
    public string type { get; init; } = type;
    public List<Operation> loading { get; set; } = [];
    public void addOperation(Operation operation)
    {
        loading.Add(operation);
    }
}