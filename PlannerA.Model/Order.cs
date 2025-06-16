using ReactiveUI.Fody.Helpers;

namespace PlannerA.Model;

public class Order
{
    [Reactive] public int order_id { get; set; }
    [Reactive] public string name { get; set; }
    [Reactive] public string client { get; set; }
    [Reactive] public DateTime date_start { get; set; }
    [Reactive] public DateTime date_end_plan { get; set; }
    [Reactive] public DateTime? date_end { get; set; }
    [Reactive] public double total_cost { get; set; }
    [Reactive] public string? description { get; set; }
    [Reactive] public bool is_active { get; set; } = true;
    [Reactive] public Dictionary<Item, int> products { get; set; } = [];
    
    public void addProducts(Item item, int quantity)
    {
        products[item] = quantity;
    }
}