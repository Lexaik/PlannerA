using System;
using System.Collections.Generic;
using PlannerA.Models;


Factory aurora = new Factory("Аврора");
Factory arsenal = new Factory("Арсенал");


Worker worker1 = new Worker("Василий Васильев", "Токарь");
Worker worker2 = new Worker("Иван Иванов", "Фрезеровщик");
Worker worker3 = new Worker("Сергей Сергеев", "Сварщик");
Worker worker4 = new Worker("Александр Александров", "Слесарь");
Worker worker5 = new Worker("Андрей Андреев", "Слесарь");

Machinery machinery1 = new Machinery("16К20", "токарный");
Machinery machinery2 = new Machinery("ВМ125м", "фрезерный");
Machinery machinery3 = new Machinery("Ресанта 250А", "Сварочный аппарат");
Machinery machinery4 = new Machinery("Набор ключей", "Слесарный инструмент");
Machinery machinery5 = new Machinery("Опрессовщик", "Слесарный инструмент");

Item item1 = new Item("Труба");
Item item2 = new Item("Лист");
Item item3 = new Item("Переход");
Item item4 = new Item("Отвод");
Item item5 = new Item("Фланец");

Operation operation1 = new Operation("Поставка", "Снабжение", DateTime.Today, DateTime.Today);
Operation operation2 = new Operation("Отрезка", "Слесарная", DateTime.Today, DateTime.Today);
Operation operation3 = new Operation("Точение", "Токарная", DateTime.Today, DateTime.Today);
Operation operation4 = new Operation("Фрезерование", "Фрезерная", DateTime.Today, DateTime.Today);
Operation operation5 = new Operation("Сварка", "Сварочная", DateTime.Today, DateTime.Today);
Operation operation6 = new Operation("Сборка", "Слесарная", DateTime.Today, DateTime.Today);


Item item0101 = new Item("Форсунка 01.01");
item0101.AddSubItems(item1, 1);
item0101.AddProcess(operation2);
item0101.AddProcess(operation3);
item0101.AddProcess(operation4);

Item item0102 = new Item("Штуцер 01.02");
item0102.AddSubItems(item1, 1);
item0102.AddProcess(operation2);
item0102.AddProcess(operation3);

Item item0100 = new Item("Распылитель 01.00");
item0100.AddSubItems(item0101,1);
item0100.AddSubItems(item0102,1);
item0100.AddProcess(operation6);


Item item0201 = new Item("Корпус 02.01");
item0201.AddSubItems(item5,2);
item0201.AddSubItems(item3,1);
item0201.AddProcess(operation5);

Item item0202 = new Item("Вставка 02.02");
item0202.AddSubItems(item1,1);
item0202.AddProcess(operation2);
item0202.AddProcess(operation3);

Item item0200 = new Item("Огнепреградитель 02.00");
item0200.AddSubItems(item0202,1);
item0200.AddSubItems(item0201,2);
item0200.AddProcess(operation6);


Order order0001 = new Order("лукоил_0001", DateTime.Today, DateTime.Today);
order0001.AddProducts(item0100, 100);
order0001.AddProducts(item0200, 10);

Order order0002 = new Order("газпром_0002", DateTime.Today, DateTime.Today);
order0002.AddProducts(item0100, 50);

Order order0003 = new Order("транснефть_0003", DateTime.Today, DateTime.Today);
order0003.AddProducts(item0200, 30);


aurora.AddEmployee(worker1);
aurora.AddEmployee(worker2);
aurora.AddEmployee(worker3);
aurora.AddEmployee(worker4);
aurora.AddEmployee(worker5);

aurora.AddEquipment(machinery1);
aurora.AddEquipment(machinery2);
aurora.AddEquipment(machinery3);
aurora.AddEquipment(machinery4);
aurora.AddEquipment(machinery5);

aurora.AddInventories(item1, 10);
aurora.AddInventories(item2, 3);
aurora.AddInventories(item3, 30);
aurora.AddInventories(item4, 20);
aurora.AddInventories(item5, 10);


public static string searchParam = "точение";
Factory aurora = new Factory("Аврора");
var foundInst = aurora.orders.Where(a => a.Products.Conteins(searchParam));


public class Factory 
{
    public string Name { get; set; }
    public List<Worker> Employee;
    public Dictionary<Item, int> Inventories;
    public List<Machinery> Equipment;
    public List<Order> Orders;

    public Factory(string name)
    {
        this.Name = name;
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