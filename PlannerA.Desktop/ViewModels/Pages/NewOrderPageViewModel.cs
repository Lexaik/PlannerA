using System;
using System.Reactive;
using PlannerA.BLL;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using PlannerA.Model;

namespace PlannerA.Desktop.ViewModels;

public class NewOrderPageViewModel : PageViewModelBase
{
    [Reactive] public DateTimeOffset? datePicker { get; set; }
    datePicker.SelectedDate = new DateTimeOffset(new DateTime(1950, 1, 1));
    [Reactive] public Order order { get; set; } = new Order
    {
        order_id = 0,
        name = "",
        client_id = 25,
        date_start = default,
        date_end_plan = default,
        total_cost = 0
    };
    
    public ReactiveCommand<Unit, Unit> CommandSave { get; }
    
    public NewOrderPageViewModel()
    {
        OrderService order_dbc = new OrderService();
        Title = "Новый заказ";
        
        CommandSave = ReactiveCommand.CreateFromTask(async () =>
        {
            await order_dbc.InsertAsync(order);
        });
        CommandSave.ThrownExceptions.Subscribe(ex => 
        {
            Console.WriteLine($"Error saving order: {ex.Message}");
        });
    }

    public void CommandClear()
    {
        order = null;
       
    }
}

