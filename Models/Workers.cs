using System.Collections.Generic;
namespace PlannerA.Models;
public class Workers (string name, string type)
{
    public string name { get; init; } = name;
    public string type { get; init; } = type;
    public List<Process> loading { get; set; } = [];
    public void addProcess(Process x)
    {
        loading.Add(x);
    }
}