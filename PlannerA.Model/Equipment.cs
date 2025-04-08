using PlannerA.PlannerA.Model;

namespace PlannerA.Model;

public class Equipment(string _name, Department _department)
{
    public string name { get; set; } = _name;
    public string type { get; set; } = "";
    public string model { get; set; } = "";
    public string manufacturer { get; set; } = "";
    public string description { get; set; } = "";
    public double price { get; set; } = 0.0;
    public DateTime? date_of_purchase { get; set; }
    public Department department { get; set; } = _department;
    public bool isActive { get; set; } = true;
    public List<Process> loading { get; set;} = [];
    
    public void addProcess(Process x)
    {
        loading.Add(x);
    }
}