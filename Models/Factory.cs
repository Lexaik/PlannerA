using System;
using System.Collections;
using System.Collections.Generic;
using PlannerA.Models;


Factory аврора = new Factory("Аврора");

Worker васильев = new Worker("Василий Васильев", "Токарь");
Worker иванов = new Worker("Иван Иванов", "Фрезеровщик");
Worker сергеев = new Worker("Сергей Сергеев", "Сварщик");
Worker александров = new Worker("Александр Александров", "Слесарь");
Worker андреев = new Worker("Андрей Андреев", "Слесарь");

Machinery machinery1 = new Machinery("16К20", "токарный");
Machinery machinery2 = new Machinery("ВМ125м", "фрезерный");
Machinery machinery3 = new Machinery("Ресанта 250А", "Сварочный аппарат");
Machinery machinery4 = new Machinery("Набор ключей", "Слесарный инструмент");
Machinery machinery5 = new Machinery("Опрессовщик", "Слесарный инструмент");

Item труба = new Item("Труба");
Item лист = new Item("Лист");
Item переход = new Item("Переход");
Item отвод = new Item("Отвод");
Item фланец = new Item("Фланец");

Operation поставка = new Operation("Поставка", "Снабжение", DateTime.Today, DateTime.Today);
Operation отрезка = new Operation("Отрезка", "Слесарная", DateTime.Today, DateTime.Today);
Operation точение = new Operation("Точение", "Токарная", DateTime.Today, DateTime.Today);
Operation фрезерование = new Operation("Фрезерование", "Фрезерная", DateTime.Today, DateTime.Today);
Operation сварка = new Operation("Сварка", "Сварочная", DateTime.Today, DateTime.Today);
Operation сборка = new Operation("Сборка", "Слесарная", DateTime.Today, DateTime.Today);


Item форсунка_0101 = new Item("Форсунка 01.01");
форсунка_0101.addSubItems(труба, 1);
форсунка_0101.addProcess(отрезка);
форсунка_0101.addProcess(точение);
форсунка_0101.addProcess(фрезерование);

Item штуцер_0102 = new Item("Штуцер 01.02");
штуцер_0102.addSubItems(труба, 1);
штуцер_0102.addProcess(отрезка);
штуцер_0102.addProcess(точение);

Item распылитель_0100 = new Item("Распылитель 01.00");
распылитель_0100.addSubItems(форсунка_0101,1);
распылитель_0100.addSubItems(штуцер_0102,1);
распылитель_0100.addProcess(сборка);

Item корпус_0201 = new Item("Корпус 02.01");
корпус_0201.addSubItems(фланец,2);
корпус_0201.addSubItems(переход,1);
корпус_0201.addProcess(сварка);

Item вставка_0202 = new Item("Вставка 02.02");
вставка_0202.addSubItems(труба,1);
вставка_0202.addProcess(отрезка);
вставка_0202.addProcess(точение);

Item огнепреградитель_0200 = new Item("Огнепреградитель 02.00");
огнепреградитель_0200.addSubItems(вставка_0202,1);
огнепреградитель_0200.addSubItems(корпус_0201,2);
огнепреградитель_0200.addProcess(сборка);


аврора.addEmployee(васильев);
аврора.addEmployee(иванов);
аврора.addEmployee(сергеев);
аврора.addEmployee(александров);
аврора.addEmployee(андреев);

аврора.addEquipment(machinery1);
аврора.addEquipment(machinery2);
аврора.addEquipment(machinery3);
аврора.addEquipment(machinery4);
аврора.addEquipment(machinery5);

аврора.addInventories(труба, 10);
аврора.addInventories(лист, 3);
аврора.addInventories(переход, 30);
аврора.addInventories(отвод, 20);

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