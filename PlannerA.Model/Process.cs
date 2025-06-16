namespace PlannerA.Model;

public class Process
{
    public int process_id { get; set; }
    public int order_id { get; set; }
    public string item { get; set; }
    public int quantity { get; set; }
    public string operation { get; set; }
    public TimeSpan oper_duration { get; set; }
    public string type { get; set; }
    public List<Process> previousProcesses { get; set; } = [];
    public DateTime? date_start { get; set; }
    public DateTime? date_end { get; set; }
    public bool is_active { get; set; } = true;

    public void addProcess(Process x)
    {
        previousProcesses.Add(x);
    }
}