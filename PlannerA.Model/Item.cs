namespace PlannerA.Model;

public class Item
{
    public int item_id { get; set; }
    public required string name { get; set; }
    public DateTime? date_of_produce { get; set; }
    public string? parameters { get; set; }
    public double? price { get; set; }
    public required int quantity { get; set; }
    public bool is_active { get; set; } = true;
    
}