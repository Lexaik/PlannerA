using System;
using System.Reactive;
using PlannerA.BLL;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using PlannerA.Model;

namespace PlannerA.Desktop.ViewModels;

public class NewOrderPageViewModel : PageViewModelBase
{
    [Reactive] public Order order { get; set; } = new Order();
    
    public ReactiveCommand<Unit, Unit> CommandSave { get; }
    
    public NewOrderPageViewModel(OrderService order_dbc)
    {
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

