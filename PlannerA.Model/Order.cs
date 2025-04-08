namespace PlannerA.Model;

public class Order(string _name, DateTime _date_start, DateTime _date_end_plan, double _total_cost, string _client)
{
    public string name { get; set; } = _name;
    public string client { get; set; } = "";
    public DateTime date_start { get; set; } = _date_start;
    public DateTime date_end_plan { get; set; } = _date_end_plan;
    public DateTime? date_end { get; set; }
    public double total_cost { get; set; } = 0.0;
    public string description { get; set; } = "";
    public Dictionary<Item, int> products { get; set; } = [];
    
    public void addProducts(Item item, int quantity)
    {
        products[item] = quantity;
    }
}