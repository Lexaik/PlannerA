namespace PlannerA.Model;

public class Client
{
    public string name { get; set; }
    public string address { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public int worker_id { get; set; }

    public bool is_active { get; set; } = true;
}