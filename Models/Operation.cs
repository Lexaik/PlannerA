using System;

namespace PlannerA.Models;

public class Operation
{
    public string name { get; set; }
    public string type { get; set; }
    public DateTime date_start { get; set; }
    public DateTime date_execute { get; set; }

    public Operation(string name, string type, DateTime date_start, DateTime date_execute)
    {
        this.name = name;
        this.type = type;
        this.date_start = date_start;
        this.date_execute = date_execute;
    }
}