using System;

namespace PlannerA.Models;

public class Operation
{
    public string name { get; set; }
    public string type { get; set; }
    public DateTime date_start { get; set; }
    public DateTime date_execute { get; set; }
}