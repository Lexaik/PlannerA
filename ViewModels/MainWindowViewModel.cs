using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using PlannerA.Models;
using ReactiveUI.Fody.Helpers;
namespace PlannerA.ViewModels;



public class MainWindowViewModel : ViewModelBase
{
    public static DateOnly current_date;
    public static ObservableCollection<DataRow> rows;
    public static ObservableCollection<DateOnly> dates;
    [Reactive] public string? selected_content { get; set; }
    public ObservableCollection<string> contents { get; set; } = [];
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
        
        //Orders = new List<Order>()
        {
            /*new Order
            {
                name = "Заказ 1", date_start = new DateOnly(2025, 02, 03), date_end = new DateOnly(2025, 02, 08),
            },
            new Order
            {
                name = "Заказ 2", date_start = new DateOnly(2025, 02, 07), date_end = new DateOnly(2025, 02, 10)
            },
            new Order
            {
                name = "Заказ 3", date_start = new DateOnly(2025, 02, 10), date_end = new DateOnly(2025, 02, 14)
            },
            new Order
            {
                name = "Заказ 4", date_start = new DateOnly(2025, 02, 12), date_end = new DateOnly(2025, 02, 13)
            },
            new Order
            {
                name = "Заказ 5", date_start = new DateOnly(2025, 02, 14), date_end = new DateOnly(2025, 02, 14)
            },
            new Order
            {
                name = "Заказ 6", date_start = new DateOnly(2025, 02, 16), date_end = new DateOnly(2025, 02, 19)
            },*/

        };
        UpdateDates();
        UpdateRows();
    }
    //public List<Order> Orders { get; set; }

    public ObservableCollection<DataRow> Rows
    {
        get => rows;
        set

        {
            rows = value;
            OnPropertyChanged(nameof(Rows));
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
        Dates.Clear();
        for (int i = -3; i < 21; i++)
        {
            Dates.Add(current_date.AddDays(i));
        }
    }
    private static void UpdateRows()
    {
        Rows.Clear();
        foreach (var order in orders)
        {
            var row = new DataRow(order.name)
            {
                name = order.name,
                status = new List<string>(),
            };
            foreach (var date in Dates)
            {
                if (date >= order.date_start && date <= order.date_end)
                    row.status.Add("В работе");
                else row.status.Add("   ");
            };
            Rows.Add(row);
        }
    }
    
    
    
    public void SelectOrders()
    {
        selected_content = contents[0];
        UpdateDates();
        UpdateRows();
    }
    
    public void SelectMachinerys()
    {
        selected_content = contents[1];
        UpdateDates();
        UpdateRows();
    }
    
    public void SelectEmployees()
    {
        selected_content = contents[2];
        UpdateDates();
        UpdateRows();
    }
    
    public void SelectMaterials()
    {
        selected_content = contents[3];
        UpdateDates();
        UpdateRows();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}