using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace PlannerA.Models
{
    public class Factory(string name)
    {
        public string name { get; set; } = name;
        public ObservableCollection<Workers> employee { get; set; } = [];
        public ObservableCollection<Equipment> equipments { get; set; } = [];
        public Dictionary<Item, int> inventories { get; set; } = [];
        public List<Order> orders { get; set; } = [];
        public List<Process> processes { get; set; } = [];
        public void addProcesses(Process process)
        {
            processes.Add(process);
        }
        public void addEmployee(Workers workers)
        {
            employee.Add(workers);
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
}