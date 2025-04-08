using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using DynamicData;
using DynamicData.Binding;
using PlannerA.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PlannerA.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        current_date = DateTime.Today;
        rows = new ObservableCollection<DataRow>();
        dates = new ObservableCollection<DateTime>();

        contents.Add("Заказы");
        contents.Add("Оборудование");
        contents.Add("Сотрудники");
        contents.Add("Материалы");
        selected_content = contents[0];
        
        aurora = new Factory("Aurora");
        
        Item item1 = new("Труба");
        Item item2 = new("Лист");
        Item item3 = new("Переход");
        Item item4 = new("Отвод");
        Item item5 = new("Фланец");
        
        Item item0100 = new("Распылитель 01.00");
        Item item0101 = new("Форсунка 01.01");
        Item item0102 = new("Штуцер 01.02");
        Item item0200 = new("Огнепреградитель 02.00");
        Item item0201 = new("Корпус 02.01");
        Item item0202 = new("Вставка 02.02");
        
        Operation operation1 = new("Поставка", "снабжение", new TimeSpan (20,0,0,0));
        Operation operation2 = new("Отрезка", "слесарная", new TimeSpan (0,20,0));
        Operation operation3 = new("Точение", "токарная", new TimeSpan (0,10,0));
        Operation operation4 = new("Фрезерование", "фрезерная", new TimeSpan (30,0,0));
        Operation operation5 = new("Сварка", "сварочная", new TimeSpan (0,40,0));
        Operation operation6 = new("Сборка", "слесарная", new TimeSpan (0,15,0));

        Order order0001 = new("лукоил_0001", new DateTime(2025, 2, 16), new DateTime(2025,03, 20));
        Order order0002 = new("газпром_0002", new DateTime(2025, 2, 19), new DateTime(2025,04, 10));
        Order order0003 = new("транснефть_0003", new DateTime(2025, 2, 26), new DateTime(2025,05, 30));
        
        Equipment machinery1 = new("16К20", "токарная");
        Equipment machinery2 = new("ВМ125м", "фрезерная");
        Equipment machinery3 = new("Ресанта 250А", "сварочная");
        Equipment machinery4 = new("Набор ключей", "слесарная");
        Equipment machinery5 = new("Опрессовщик", "слесарная");
        Equipment machinery6 = new("Транспортная компания", "снабжение");

        Workers worker1 = new("Василий Васильев", "токарная");
        Workers worker2 = new("Иван Иванов", "фрезерная");
        Workers worker3 = new("Сергей Сергеев", "сварочная");
        Workers worker4 = new("Александр Александров", "слесарная");
        Workers worker5 = new("Андрей Андреев", "снабжение");
        
        item0101.addSubItems(item1, 1);
        item0101.addOperation(operation2);
        item0101.addOperation(operation3);
        item0101.addOperation(operation4);
        item0102.addSubItems(item1, 1);
        item0102.addOperation(operation2);
        item0102.addOperation(operation3);
        item0100.addSubItems(item0101, 1);
        item0100.addSubItems(item0102, 1);
        item0100.addOperation(operation6);
        item0201.addSubItems(item5, 2);
        item0201.addSubItems(item3, 1);
        item0201.addOperation(operation5);
        item0202.addSubItems(item1, 1);
        item0202.addOperation(operation2);
        item0202.addOperation(operation3);
        item0200.addSubItems(item0202, 1);
        item0200.addSubItems(item0201, 2);
        item0200.addOperation(operation6);
        
        order0001.addProducts(item0100, 1000);
        order0001.addProducts(item0200, 10000);
        order0002.addProducts(item0100, 5000);
        order0003.addProducts(item0200, 3000);

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
        aurora.addEquipment(machinery6);

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
        DataProcess.UpdateProcesses();

        this.WhenValueChanged(vm => vm.selected_content).Subscribe(p=>UpdateRows());
    }
    
    public static DateTime current_date;
    public static ObservableCollection<DataRow> rows;
    public static ObservableCollection<DateTime> dates;
    public ObservableCollection<string> contents { get; set; } = [];
    [Reactive] public string? selected_content { get; set; }

    public static Factory aurora { get; set;}
    
    public ObservableCollection<DataRow> Rows
    {
        get => rows;
        set
        {
            rows = value;
            OnPropertyChanged(nameof(rows));
        }
    }
    public ObservableCollection<DateTime> Dates
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
        for (int i = -3; i < 7; i++)
        {
            dates.Add(current_date.AddDays(i));
        }
    }
    private void UpdateRows()
    {
        rows.Clear();
        switch (selected_content)
        {
            case "Заказы":
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
                break;
            case "Оборудование":
                foreach (var equipment in aurora.equipments)
                {
                    var row = new DataRow(equipment.name)
                    {
                        name = equipment.name,
                        status = new List<string>(),
                    };
                    foreach (var date in dates)
                    {
                        var proc = equipment.loading.Where(x => x.date_start <= date && x.date_end >= date).FirstOrDefault();
                        if ( proc != null ) row.status.Add(proc.order+proc.operation+proc.item);
                        else row.status.Add("");
                    };
                    rows.Add(row);
                }
                break;
           case "Сотрудники":
                foreach (var worker in aurora.employee)
                {
                    var row = new DataRow(worker.name)
                    {
                        name = worker.name,
                        status = new List<string>(),
                    };
                    foreach (var date in dates)
                    {
                        var proc = worker.loading.Where(x => x.date_start <= date && x.date_end >= date).FirstOrDefault();
                        if ( proc != null ) row.status.Add(proc.order+"-"+proc.operation+"-"+proc.item);
                        else row.status.Add("");
                    };
                    rows.Add(row);
                }
                break;
            case "Материалы":
                foreach (var pos in aurora.inventories)
                {
                    var row = new DataRow(pos.Key.name)
                    {
                        name = pos.Key.name,
                        status = new List<string>(),
                    };
                    foreach (var date in dates)
                    {
                        /*if (date >= order.date_start && date <= order.date_end)
                            row.status.Add("В работе");// Исправить на номера заказов
                        else*/ row.status.Add("");
                    };
                    rows.Add(row);
                }
                break;
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
        current_date = DateTime.Today;
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