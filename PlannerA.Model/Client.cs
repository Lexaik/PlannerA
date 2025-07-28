namespace PlannerA.Model;

public class Client
{
    public required int client_id { get; set; }
    public required string name { get; set; }
    public required string address { get; set; }
    public required string phone { get; set; }
    public string? email { get; set; }
    public required int worker_id { get; set; }
    public bool is_active { get; set; } = true;
}