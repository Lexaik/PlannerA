using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DynamicData;
using PlannerA.Models;
using ReactiveUI.Fody.Helpers;

namespace PlannerA.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        current_date = DateOnly.FromDateTime(DateTime.Today);
        rows = new ObservableCollection<DataRow>();
        dates = new ObservableCollection<DateOnly>();

        contents.Add("Заказы");
        contents.Add("Оборудование");
        contents.Add("Сотрудники");
        contents.Add("Материалы");
        selected_content = contents[0];
        
        aurora = new Factory("Aurora");
        
        item1 = new("Труба");
        item2 = new("Лист");
        item3 = new("Переход");
        item4 = new("Отвод");
        item5 = new("Фланец");
        
        item0100 = new("Распылитель 01.00");
        item0101 = new("Форсунка 01.01");
        item0102 = new("Штуцер 01.02");
        item0200 = new("Огнепреградитель 02.00");
        item0201 = new("Корпус 02.01");
        item0202 = new("Вставка 02.02");
        
        operation1 = new("Поставка", "Снабжение", new TimeSpan (20,0,0,0));
        operation2 = new("Отрезка", "Слесарная", new TimeSpan (0,20,0));
        operation3 = new("Точение", "Токарная", new TimeSpan (0,10,0));
        operation4 = new("Фрезерование", "Фрезерная", new TimeSpan (30,0,0));
        operation5 = new("Сварка", "Сварочная", new TimeSpan (0,40,0));
        operation6 = new("Сборка", "Слесарная", new TimeSpan (0,15,0));

        order0001 = new("лукоил_0001", new DateOnly(2025, 2, 16), new DateOnly(2025,03, 20));
        order0002 = new("газпром_0002", new DateOnly(2025, 2, 19), new DateOnly(2025,04, 10));
        order0003 = new("транснефть_0003", new DateOnly(2025, 2, 26), new DateOnly(2025,05, 30));
        
        machinery1 = new("16К20", "токарный");
        machinery2 = new("ВМ125м", "фрезерный");
        machinery3 = new("Ресанта 250А", "Сварочный аппарат");
        machinery4 = new("Набор ключей", "Слесарный инструмент");
        machinery5 = new("Опрессовщик", "Слесарный инструмент");

        worker1 = new("Василий Васильев", "Токарь");
        worker2 = new("Иван Иванов", "Фрезеровщик");
        worker3 = new("Сергей Сергеев", "Сварщик");
        worker4 = new("Александр Александров", "Слесарь");
        worker5 = new("Андрей Андреев", "Слесарь");
        
        item0101.addSubItems(item1, 1);
        item0101.addProcess(operation2);
        item0101.addProcess(operation3);
        item0101.addProcess(operation4);
        item0102.addSubItems(item1, 1);
        item0102.addProcess(operation2);
        item0102.addProcess(operation3);
        item0100.addSubItems(item0101, 1);
        item0100.addSubItems(item0102, 1);
        item0100.addProcess(operation6);
        item0201.addSubItems(item5, 2);
        item0201.addSubItems(item3, 1);
        item0201.addProcess(operation5);
        item0202.addSubItems(item1, 1);
        item0202.addProcess(operation2);
        item0202.addProcess(operation3);
        item0200.addSubItems(item0202, 1);
        item0200.addSubItems(item0201, 2);
        item0200.addProcess(operation6);
        
        order0001.addProducts(item0100, 100);
        order0001.addProducts(item0200, 10);
        order0002.addProducts(item0100, 50);
        order0003.addProducts(item0200, 30);

        aurora.addEmployee(worker1);
        aurora.addEmployee(worker2);
        aurora.addEmployee(worker3);
        aurora.addEmployee(worker4);
        aurora.addEmployee(worker5);

        aurora.addEquipment(machinery1);
        aurora.addEquipment(machinery2);
        aurora.addEquipment(machinery3);
        aurora.addEquipment(machinery4);
        aurora.addEquipment(machinery5);

        aurora.addInventories(item1, 10);
        aurora.addInventories(item2, 3);
        aurora.addInventories(item3, 30);
        aurora.addInventories(item4, 20);
        aurora.addInventories(item5, 10);
        
        aurora.addOrder(order0001);
        aurora.addOrder(order0002);
        aurora.addOrder(order0003);
        
        UpdateDates();
        UpdateRows();
    }
    
    public static DateOnly current_date;
    public static ObservableCollection<DataRow> rows;
    public static ObservableCollection<DateOnly> dates;
    public ObservableCollection<string> contents { get; set; } = [];
    [Reactive] public string? selected_content { get; set; }
    public static Factory aurora { get; set;}
    
    Item item1;
    Item item2;
    Item item3;
    Item item4;
    Item item5;
        
    Item item0100;
    Item item0101;
    Item item0102;
    Item item0200;
    Item item0201;
    Item item0202;
        
    Operation operation1;
    Operation operation2;
    Operation operation3;
    Operation operation4;
    Operation operation5;
    Operation operation6;

    Order order0001;
    Order order0002;
    Order order0003;
        
    Equipment machinery1;
    Equipment machinery2;
    Equipment machinery3;
    Equipment machinery4;
    Equipment machinery5;

    Workers worker1;
    Workers worker2;
    Workers worker3;
    Workers worker4;
    Workers worker5;
        
    /*public static string work = "слесарь";
    public List<Workers> foundWorker = aurora.employee.Where(x => x.name.Contains(work)).ToList();
    public static string search_opp = "Токарная";
    public static List<char>resultOpp = aurora.orders.SelectMany(a => a.products)
        .SelectMany(b => b.Key.process)
        .SelectMany(c => c.type).ToList();*/
    
    public ObservableCollection<DataRow> Rows
    {
        get => rows;
        set
        {
            rows = value;
            OnPropertyChanged(nameof(rows));
        }
    }
    public ObservableCollection<DateOnly> Dates
    {
        get => dates;
        set
        {
            dates = value;
            OnPropertyChanged(nameof(Dates));
        }
    }
    private static void UpdateDates()
    {
        dates.Clear();
        for (int i = -3; i < 21; i++)
        {
            dates.Add(current_date.AddDays(i));
        }
    }
    private static void UpdateRows()
    {
        rows.Clear();
        foreach (var order in aurora.orders)
        {
            var row = new DataRow(order.name)
            {
                name = order.name,
                status = new List<string>(),
            };
            foreach (var date in dates)
            {
                if (date >= order.date_start && date <= order.date_end)
                    row.status.Add("В работе");
                else row.status.Add("");
            };
            rows.Add(row);
        }
    }
    
    public void ScrollForward()
    {
        current_date = current_date.AddDays(1);
        UpdateDates();
        UpdateRows();
    }
    public void SetToday()
    {
        current_date = DateOnly.FromDateTime(DateTime.Today);
        UpdateDates();
        UpdateRows();
    }
    public void ScrollBackward()
    {
        current_date = current_date.AddDays(-1);
        UpdateDates();
        UpdateRows();
    }
    public void ScrollWeek()
    {
        current_date = current_date.AddDays(7);
        UpdateDates();
        UpdateRows();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}