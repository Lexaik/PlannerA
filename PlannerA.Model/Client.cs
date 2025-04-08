using PlannerA.Model;

namespace PlannerA.PlannerA.Model;

public class Client (string _name, string _address, string _phone, Worker _manager)
{
    public string name { get; init; } = _name;
    public string address { get; init; } = _address;
    public string phone { get; init; } = _phone;
    public string email { get; init; }
    public Worker manager { get; init; } = _manager;
}