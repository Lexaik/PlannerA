using System;

namespace PlannerA.Models;

public class Operation
{
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateExecute { get; set; }
    public Operation(string name, string type, DateTime dateStart, DateTime dateExecute)
    {
        Name = name;
        Type = type;
    }

    
}