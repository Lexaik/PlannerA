using System;
namespace PlannerA.Models;
public class Operation (string name, string type, DateTime dateStart, DateTime dateExecute)
{
    public string name { get; set; } = name;
    public string type { get; set; } = type;
    public DateTime dateStart { get; set; } = dateStart;
    public DateTime dateExecute { get; set; } = dateExecute;
}