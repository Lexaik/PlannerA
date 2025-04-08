namespace PlannerA.Model;

public class Operation (string _name, TimeSpan _duration)
{
    public string name { get; set; } = _name;
    public string type { get; set; } = "";
    public TimeSpan duration { get; set; } = _duration;
    public string parameters { get; set; } = "";
    public double cost { get; set; } = 0.0;
}