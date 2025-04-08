using PlannerA.Model.obj;
using PlannerA.PlannerA.Model;

namespace PlannerA.Model;

public class Worker (Person _person, string _specialization, DateTime _date_of_hire, Department _department)
{
    public Person person { get; init; } = _person;
    public string specialization { get; init; } = _specialization;
    public DateTime date_of_hire { get; set; } = _date_of_hire;
    public DateTime? date_of_separation  { get; set; }
    public string education { get; set; } = "unknown";
    public DateTime? date_of_education_end  { get; set; }
    public Department department { get; set; } = _department;
    public double salary { get; set; } = 0.0;
    public bool is_active { get; set; } = true;
    public List<Process> loading { get; set; } = [];
    
    public void addProcess(Process x)
    {
        loading.Add(x);
    }
}