namespace PlannerA.Model;

public class Operation
{
    public string name { get; set; }
    public string type { get; set; }
    public TimeSpan duration { get; set; }
    public string parameters { get; set; }
    public double cost { get; set; }

    public bool is_active { get; set; } = true;
}