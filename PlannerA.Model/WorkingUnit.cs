namespace PlannerA.Model;

public class WorkingUnit
{
    public required int working_unit_id { get; set; }
    public required string name { get; set; }
    public required int worker_id { get; set; }
    public required int equipment_id { get; set; }
    public bool is_active { get; set; }
}