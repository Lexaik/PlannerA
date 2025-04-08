using System.Collections.ObjectModel;

namespace PlannerA.Model;

public class Factory(string name)
{
    public string name { get; set; } = name;
    public ObservableCollection<Worker> employee { get; set; } = [];
    public ObservableCollection<Equipment> equipments { get; set; } = [];
    public Dictionary<Item, int> inventories { get; set; } = [];
    public List<Order> orders { get; set; } = [];
    public List<Process> processes { get; set; } = [];
    public void addProcesses(Process process)
    {
        processes.Add(process);
    }
    public void addEmployee(Worker worker)
    {
        employee.Add(worker);
    }
    public void addEquipment(Equipment equipment)
    {
        equipments.Add(equipment);
    }
    public void addInventories(Item item, int quantity)
    {
        inventories[item] = quantity;
    }
    public void addOrder(Order order)
    {
        orders.Add(order);
    }
}