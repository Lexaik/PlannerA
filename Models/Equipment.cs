using System.Collections.Generic;
namespace PlannerA.Models;
public class Equipment(string name, string type)
{
    public string Name { get; set; } = name;
    public string Type { get; set; } = type;
    public List<Operation> loading { get; set;} = [];
    public void addOperation(Operation operation)
    {
        loading.Add(operation);
    }
}