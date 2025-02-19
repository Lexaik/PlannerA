using System;
namespace PlannerA.Models;
public class Operation (string name, string type, TimeSpan duration)
{
    public string name { get; set; } = name;
    public string type { get; set; } = type;
    public TimeSpan duration { get; set; } = duration;
}