namespace PlannerA.Model;

public class Operation
{
    public required int operation_id { get; set; }
    public required string name { get; set; }
    public required TimeSpan duration { get; set; }
    public string? parameters { get; set; }
    public required double cost { get; set; }

    public bool is_active { get; set; } = true;
}