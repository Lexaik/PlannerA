using System.Collections.Generic;

namespace PlannerA.Models;

public class Factory
{
    public string Name { get; set; }
    public List<Worker> Employee;
    public List<Machinery> Equipment;
    public Dictionary<Item, int> Inventories;
    public List<Order> Orders;

    public Factory(string name)
    {
        Name = name;
        Employee = new List<Worker>();
        Inventories = new Dictionary<Item, int>();
        Equipment = new List<Machinery>();
        Orders = new List<Order>();
    }

    public void AddEmployee(Worker worker)
    {
        Employee.Add(worker);
    }

    public void AddInventories(Item item, int quantity)
    {
        Inventories[item] = quantity;
    }

    public void AddEquipment(Machinery machinery)
    {
        Equipment.Add(machinery);
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }
}