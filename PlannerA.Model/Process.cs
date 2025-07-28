namespace PlannerA.Model;

public class Process
{
    public required int process_id { get; set; }
    public required int operation_id { get; set; }
    public required int order_id { get; set; }
    public bool is_active { get; set; } = true;

}