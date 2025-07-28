using ReactiveUI.Fody.Helpers;

namespace PlannerA.Model;

public class Order
{
    [Reactive] public required int order_id { get; set; }
    [Reactive] public required string name { get; set; }
    [Reactive] public required int client_id { get; set; }
    [Reactive] public required DateTimeOffset date_start { get; set; }
    [Reactive] public required DateTime date_end_plan { get; set; }
    [Reactive] public DateTime? date_end { get; set; }
    [Reactive] public required double total_cost { get; set; }
    [Reactive] public string? description { get; set; }
    [Reactive] public bool is_active { get; set; } = true;
    
}