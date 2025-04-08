using PlannerA.Model.obj;

namespace PlannerA.PlannerA.Model;

public class Department (string _name, Person _person)
{
    public string name { get; set; } = _name;
    public Person leader { get; set; } = _person;
    public string description { get; set; } = "";
}