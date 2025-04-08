using System;
using System.Collections.Generic;

namespace PlannerA.Models;

public class Process
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string? order { get; set; }
    public string item { get; set; }
    public int? quantity { get; set; }
    public string operation { get; set; }
    public TimeSpan operDur { get; set; }
    public string type { get; set; }
    public List<Process> previousProcesses { get; set; } = [];
    public DateTime? date_start { get; set; }
    public DateTime? date_end { get; set; }
    
}