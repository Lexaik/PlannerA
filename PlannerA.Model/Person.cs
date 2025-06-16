namespace PlannerA.Model;

public class Person
{
    public int person_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string patronymic { get; set; }
    public DateTime date_of_birth { get; set; }
    public bool is_active { get; set; } = true;
}