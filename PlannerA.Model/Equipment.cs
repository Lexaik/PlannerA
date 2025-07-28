using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerA.Model;

public class Equipment
{
    public required int equipment_id { get; set; }
    public required string name { get; set; }
    public string? model { get; set; }
    public string? manufacturer { get; set; }
    public string? parameters { get; set; }
    public required double price { get; set; }
    public DateTime? date_of_purchase { get; set; }
    public bool is_active { get; set; } = true;
    
}