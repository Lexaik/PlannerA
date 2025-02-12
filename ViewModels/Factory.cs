using System.Collections.Generic;

namespace PlannerA.Models
{
    public class Factory(string name)
    {
        public string name { get; set; } = name;
        public List<Workers> employee { get; set; } = [];
        public List<Equipment> equipments { get; set; } = [];
        public Dictionary<Item, int> inventories { get; set; } = new Dictionary<Item, int>();
        public List<Order> orders { get; set; } = [];

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

        
        
        
        
        

        private Factory aurora = new("Аврора");

        private Item item0100 = new("Распылитель 01.00");

        private Item item0101 = new("Форсунка 01.01");

        private Item item0102 = new("Штуцер 01.02");

        private Item item0200 = new("Огнепреградитель 02.00");

        private Item item0201 = new("Корпус 02.01");

        private Item item0202 = new("Вставка 02.02");

        private Item item1 = new("Труба");
        private Item item2 = new("Лист");
        private Item item3 = new("Переход");
        private Item item4 = new("Отвод");
        private Item item5 = new("Фланец");

        private Equipment machinery1 = new("16К20", "токарный");
        private Equipment machinery2 = new("ВМ125м", "фрезерный");
        private Equipment machinery3 = new("Ресанта 250А", "Сварочный аппарат");
        private Equipment machinery4 = new("Набор ключей", "Слесарный инструмент");
        private Equipment machinery5 = new("Опрессовщик", "Слесарный инструмент");

        private Operation operation1 = new("Поставка", "Снабжение", DateTime.Today, DateTime.Today);
        private Operation operation2 = new("Отрезка", "Слесарная", DateTime.Today, DateTime.Today);
        private Operation operation3 = new("Точение", "Токарная", DateTime.Today, DateTime.Today);
        private Operation operation4 = new("Фрезерование", "Фрезерная", DateTime.Today, DateTime.Today);
        private Operation operation5 = new("Сварка", "Сварочная", DateTime.Today, DateTime.Today);
        private Operation operation6 = new("Сборка", "Слесарная", DateTime.Today, DateTime.Today);

        private Order order0001 = new Order("лукоил_0001", DateOnly(2022, 1, 6), 25.10 .20);

        private Order order0002 = new Order("газпром_0002", DateTime.Today, DateTime.Today);

        private Order order0003 = new Order("транснефть_0003", DateTime.Today, DateTime.Today);

        private Workers worker1 = new("Василий Васильев", "Токарь");
        private Workers worker2 = new("Иван Иванов", "Фрезеровщик");
        private Workers worker3 = new("Сергей Сергеев", "Сварщик");
        private Workers worker4 = new("Александр Александров", "Слесарь");
        private Workers worker5 = new("Андрей Андреев", "Слесарь");
        item0101.AddSubItems(item1, 1);
        item0101.AddProcess(operation2);
        item0101.AddProcess(operation3);
        item0101.AddProcess(operation4);
        item0102.AddSubItems(item1, 1);
        item0102.AddProcess(operation2);
        item0102.AddProcess(operation3);
        item0100.AddSubItems(item0101, 1);
        item0100.AddSubItems(item0102, 1);
        item0100.AddProcess(operation6);
        item0201.AddSubItems(item5, 2);
        item0201.AddSubItems(item3, 1);
        item0201.AddProcess(operation5);
        item0202.AddSubItems(item1, 1);
        item0202.AddProcess(operation2);
        item0202.AddProcess(operation3);
        item0200.AddSubItems(item0202, 1);
        item0200.AddSubItems(item0201, 2);
        item0200.AddProcess(operation6);
        order0001.AddProducts(item0100, 100);
        order0001.AddProducts(item0200, 10);
        order0002.AddProducts(item0100, 50);
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


        var aurora = new Factory("Аврора");

        var worker1 = new Workers("Василий Васильев", "Токарь");
        var worker2 = new Workers("Иван Иванов", "Фрезеровщик");
        var worker3 = new Workers("Сергей Сергеев", "Сварщик");
        var worker4 = new Workers("Александр Александров", "Слесарь");
        var worker5 = new Workers("Андрей Андреев", "Слесарь");

        var machinery1 = new Equipment("16К20", "токарный");
        var machinery2 = new Equipment("ВМ125м", "фрезерный");
        var machinery3 = new Equipment("Ресанта 250А", "Сварочный аппарат");
        var machinery4 = new Equipment("Набор ключей", "Слесарный инструмент");
        var machinery5 = new Equipment("Опрессовщик", "Слесарный инструмент");

        var item1 = new Item("Труба");
        var item2 = new Item("Лист");
        var item3 = new Item("Переход");
        var item4 = new Item("Отвод");
        var item5 = new Item("Фланец");

        var operation1 = new Operation("Поставка", "Снабжение", DateTime.Today, DateTime.Today);
        var operation2 = new Operation("Отрезка", "Слесарная", DateTime.Today, DateTime.Today);
        var operation3 = new Operation("Точение", "Токарная", DateTime.Today, DateTime.Today);
        var operation4 = new Operation("Фрезерование", "Фрезерная", DateTime.Today, DateTime.Today);
        var operation5 = new Operation("Сварка", "Сварочная", DateTime.Today, DateTime.Today);
        var operation6 = new Operation("Сборка", "Слесарная", DateTime.Today, DateTime.Today);

        var item0101 = new Item("Форсунка 01.01");
        item0101.AddSubItems(item1, 1);
        item0101.AddProcess(operation2);
        item0101.AddProcess(operation3);
        item0101.AddProcess(operation4);

        var item0102 = new Item("Штуцер 01.02");
        item0102.AddSubItems(item1, 1);
        item0102.AddProcess(operation2);
        item0102.AddProcess(operation3);

        var item0100 = new Item("Распылитель 01.00");
        item0100.AddSubItems(item0101, 1);
        item0100.AddSubItems(item0102, 1);
        item0100.AddProcess(operation6);

        var item0201 = new Item("Корпус 02.01");
        item0201.AddSubItems(item5, 2);
        item0201.AddSubItems(item3, 1);
        item0201.AddProcess(operation5);

        var item0202 = new Item("Вставка 02.02");
        item0202.AddSubItems(item1, 1);
        item0202.AddProcess(operation2);
        item0202.AddProcess(operation3);

        var item0200 = new Item("Огнепреградитель 02.00");
        item0200.AddSubItems(item0202, 1);
        item0200.AddSubItems(item0201, 2);
        item0200.AddProcess(operation6);

        var order0001 = new Order("лукоил_0001", DateOnly(2022, 1, 6), 25.10 .20);
        order0001.AddProducts(item0100, 100);
        order0001.AddProducts(item0200, 10);

        var order0002 = new Order("газпром_0002", DateTime.Today, DateTime.Today);
        order0002.AddProducts(item0100, 50);

        var order0003 = new Order("транснефть_0003", DateTime.Today, DateTime.Today);
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


    }
}