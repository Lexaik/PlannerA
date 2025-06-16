namespace PlannerA.Model;

public class Department
{
    public string name { get; set; }
    public int person_id { get; set; }
    public string description { get; set; }
    public bool is_active { get; set; } = true;
}