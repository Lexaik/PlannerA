namespace PlannerA.Model;

public class Equipment
{
    public int equipment_id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string model { get; set; }
    public string manufacturer { get; set; }
    public string description { get; set; }
    public double price { get; set; }
    public DateTime? date_of_purchase { get; set; }
    public string department { get; set; }
    public bool is_active { get; set; } = true;
    public List<Process> loading { get; set; } = [];
    
    public void addProcess(Process x)
    {
        loading.Add(x);
    }
}