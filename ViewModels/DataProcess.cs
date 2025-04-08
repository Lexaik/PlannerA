using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PlannerA.Models;
using ReactiveUI;


namespace PlannerA.ViewModels;

public class DataProcess
{
    public DataProcess(Factory factory)
    {
        processes = new ObservableCollection<Process>();
        current_date = DateTime.Today;
        UpdateProcesses();
    }
    
    public static DateTime current_date;
    public static ObservableCollection<Process> processes;

    public static void UpdateProcesses()
    {
        if (processes != null) processes.Clear();
        foreach (var order in MainWindowViewModel.aurora.orders)
        {
            if (order.date_end_plan > current_date)
            {
                processes = new ObservableCollection<Process>(makeProcess(order.products,
                    out List<Process> prevProcesses));
            }
        }
        DistributeProcesses();
        foreach (var order in MainWindowViewModel.aurora.orders)
        ActualizationDateInProcesses(order);
        foreach (var order in MainWindowViewModel.aurora.orders)
        {
           //order.date_end = // присвоить дату последнего процесса окончанию заказа
        }
    }

    public static List<Process> makeProcess(Dictionary<Item, int> items, out List<Process> prevProcesses)
    {
        var result = new List<Process>();
        prevProcesses = new List<Process>();
        foreach (var itemA in items.Keys)
        {
            var result1 = new List<Process>();
            var prev = new List<Process>();
            var result2 = makeProcess(itemA.subItems, out prev);
            foreach (var process in result2)
            {
                process.quantity *= items[itemA];
            }
            result.AddRange(result2);
            foreach (var oper in itemA.operations)
            {
                var process = new Process()
                {
                    item = itemA.name,
                    quantity = items[itemA],
                    operation = oper.name,
                    operDur = oper.duration,
                    type = oper.type,
                };
                if (result1.Count != 0) process.previousProcesses.Add(result1[(result1.Count) - 1]);
                else if (result1.Count == 0 && result2.Count != 0) process.previousProcesses.AddRange(prev);
                result1.Add(process);
            }
            if (result1.Count !=0) prevProcesses.Add(result1[result1.Count - 1]);
            result.AddRange(result1);
        }
        return result;
    }
    
    public static void DistributeProcesses()
    {
        foreach (var process in processes)
        {
            var equipment = MainWindowViewModel.aurora.equipments.FirstOrDefault(c => c.Type == process.type);
            equipment?.loading.Add(process);
            
            var worker = MainWindowViewModel.aurora.employee.FirstOrDefault(c => c.type == process.type);
            worker?.loading.Add(process);
        }
    }

    public static void ActualizationDateInProcesses(Order order)
    {
        foreach (var proc in processes)
        {
            proc.order = order.name;
            if (proc.previousProcesses.Count == 0)
            {
                proc.date_start = order.date_start;
            }
            else
            {
                var date = proc.previousProcesses.Where(x => x.date_end.HasValue).Max(x => x.date_end.Value);
                proc.date_start = date.AddDays(1);
            }
            proc.date_end = proc.date_start.Value.Add(proc.operDur.Multiply(proc.quantity.Value));
        }

        foreach (var equip in MainWindowViewModel.aurora.equipments)
        {
            for (int i=1; i< equip.loading.Count(); i++)
            {
              Process previous = equip.loading[i - 1];
              Process current = equip.loading[i];
              if (previous.date_end >= current.date_start)
              current.date_start = previous.date_end.Value.AddDays(1);
            }
        }
        
        foreach (var worker in MainWindowViewModel.aurora.employee)
        {
            for (int i=1; i< worker.loading.Count(); i++)
            {
                Process previous = worker.loading[i - 1];
                Process current = worker.loading[i];
                if (previous.date_end >= current.date_start)
                    current.date_start = previous.date_end.Value.AddDays(1);
            }
        }
    }
    
    public ObservableCollection<Process> Processes
    {
        get => processes;
        set
        {
            processes = value;
            OnPropertyChanged(nameof(processes));
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


