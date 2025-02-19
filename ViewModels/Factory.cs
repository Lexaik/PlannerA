using System.Collections.Generic;

namespace PlannerA.Models
{
    public class Factory(string name)
    {
        public string name { get; set; } = name;
        public List<Workers> employee { get; set; } = [];
        public List<Equipment> equipments { get; set; } = [];
        public Dictionary<Item, int> inventories { get; set; } = [];
        public List<Order> orders { get; set; } = [];
        public void addEmployee(Workers workers)
        {
            employee.Add(workers); }
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