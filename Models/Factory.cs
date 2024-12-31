using System.Collections;
using System.Collections.Generic;

namespace PlannerA.Models;
public class Factory 
{
    public string name { get; set; }
    public List<Worker> employee;
    public Dictionary<Item, int> inventories;
    public List<Machinery> equipment;
    public List<Order> orders;

    public Factory(string name)
    {
        this.name = name;
        employee = new List<Worker>();
        inventories = new Dictionary<Item, int>();
        equipment = new List<Machinery>();
        orders = new List<Order>();
    }

        public void addEmployee(Worker worker)
        {
            employee.Add(worker);
        }

        public void addInventories(Item item, int quantity)
        {
            inventories[item] = quantity;
        }

        public void addEquipment(Machinery machinery)
        {
            equipment.Add(machinery);
        }

        public void addOrder(Order order)
        {
            orders.Add(order);
        }
    
}