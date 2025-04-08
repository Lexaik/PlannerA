using System.Collections.Generic;
namespace PlannerA.Models;
public class Equipment(string name, string type)
{
    public string name { get; set; } = name;
    public string Type { get; set; } = type;
    public List<Process> loading { get; set;} = [];
    public void addProcess(Process x)
    {
        loading.Add(x);
    }
}