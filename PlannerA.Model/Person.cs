namespace PlannerA.Model;

public class Person
{
    public required int person_id { get; set; }
    public required string first_name { get; set; }
    public required string last_name { get; set; }
    public string? patronymic { get; set; }
    public required DateTime date_of_birth { get; set; }
    public required string phone { get; set; }
    public required string address { get; set; }
    public bool is_active { get; set; } = true;
}