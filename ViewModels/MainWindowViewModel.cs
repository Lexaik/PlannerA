using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PlannerA.Models;

namespace PlannerA.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public DateOnly _currentDate;
    public ObservableCollection<DataRow> _rows;
    public ObservableCollection<DateOnly> _dates;

    public MainWindowViewModel()
    {
        _currentDate = DateOnly.FromDateTime(DateTime.Today);
        _rows = new ObservableCollection<DataRow>();
        _dates = new ObservableCollection<DateOnly>();
        Orders = new List<Order>
        {
            new Order
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
            },
            
        };
        UpdateDates();
        UpdateRows();
    }
    public List<Order> Orders { get; set; }

    public ObservableCollection<DataRow> Rows
    {
        get => _rows;
        set

        {
            _rows = value;
            OnPropertyChanged(nameof(Rows));
        }
    }
    public ObservableCollection<DateOnly> Dates
    {
        get => _dates;
        set
        {
            _dates = value;
            OnPropertyChanged(nameof(Dates));
        }
    }
    private void UpdateDates()
    {
        Dates.Clear();
        for (int i = -3; i < 21; i++)
        {
            Dates.Add(_currentDate.AddDays(i));
        }
    }
    private void UpdateRows()
    {
        Rows.Clear();
        foreach (var order in Orders)
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
    
    public void ScrollForward()
    {
        _currentDate = _currentDate.AddDays(1);
        UpdateDates();
        UpdateRows();
    }
    public void SetToday()
    {
        _currentDate = DateOnly.FromDateTime(DateTime.Today);
        UpdateDates();
        UpdateRows();
    }
    public void ScrollBackward()
    {
        _currentDate = _currentDate.AddDays(-1);
        UpdateDates();
        UpdateRows();
    }
    public void ScrollWeek()
    {
        _currentDate = _currentDate.AddDays(7);
        UpdateDates();
        UpdateRows();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}