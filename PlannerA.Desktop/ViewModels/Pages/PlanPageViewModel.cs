using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PlannerA.BLL;
using ReactiveUI.Fody.Helpers;


namespace PlannerA.Desktop.ViewModels;

public class PlanPageViewModel : PageViewModelBase
{
    public static DateTime current_date;
    public static ObservableCollection<DataRow> rows;
    public static ObservableCollection<DateTime> dates;
    public static Factory aurora = new();
    public ObservableCollection<string> contents { get; set; } = [];
    [Reactive] public string? selected_content { get; set; }
    
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
        for (int i = -3; i < 14; i++)
        {
            dates.Add(current_date.AddDays(i));
        }
    }
    private static void UpdateRows()
    {
        rows.Clear();
        foreach (var order in aurora.orders)
        {
            var row = new DataRow(order.name);
            foreach (var date in dates)
            {
                if (date >= order.date_start && date <= order.date_end_plan)
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
    public PlanPageViewModel()
    {
        Title = "План";
        var aurora = new Factory();
        current_date = DateTime.Today;
        rows = new ObservableCollection<DataRow>();
        dates = new ObservableCollection<DateTime>();
        
        contents = ["Заказы", "Оборудование", "Сотрудники", "Материалы"];
        selected_content = contents[0];
        
        UpdateDates();
        UpdateRows();
    }
}