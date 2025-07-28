namespace PlannerA.Model;

public class OperationLinks
{
    public required int id { get; set; }
    public required int operation_id { get; set; }
    public required int out_item_id { get; set; }
    public required int in_item_id { get; set; }
    public int? supply_item_id { get; set; }
    public int? tail_item_id { get; set; }
}