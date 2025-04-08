using System.Collections.ObjectModel;
using DynamicData;
using PlannerA.BLL;
using PlannerA.Model;

namespace PlannerA.Desktop.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    public ObservableCollection<Order> Orders { get; } = [];
    
      
    public MainPageViewModel(ICrudService crudService)
    {
        Title = "Заказы";
        var orders = crudService.GetAll();
        Orders.Clear();
        foreach (var order in orders)
        {
            Orders.Add(order);
        }
    }
}