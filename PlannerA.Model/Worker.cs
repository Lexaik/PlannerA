namespace PlannerA.Model;

public class Worker
{
    public required int worker_id { get; set; }
    public required string name { get; init; }
    public required int person_id { get; init; }
    public required DateTime date_of_hire { get; set; }
    public DateTime? date_of_separation  { get; set; }
    public string? education { get; set; }
    public DateTime? date_of_education_end  { get; set; }
    public double salary { get; set; }
    public bool is_active { get; set; }
}