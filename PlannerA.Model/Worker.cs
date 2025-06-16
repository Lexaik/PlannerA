namespace PlannerA.Model;

public class Worker
{
    public int person_id { get; init; }
    public string specialization { get; init; }
    public DateTime date_of_hire { get; set; }
    public DateTime? date_of_separation  { get; set; }
    public string? education { get; set; }
    public DateTime? date_of_education_end  { get; set; }
    public string department { get; set; }
    public double salary { get; set; }
    public bool is_active { get; set; }
    public List<Process> loading { get; set; } = [];
    
    public void addProcess(Process x)
    {
        loading.Add(x);
    }
}