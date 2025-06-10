using System.Collections.ObjectModel;
using PlannerA.BLL;
using ReactiveUI.Fody.Helpers;

namespace PlannerA.Desktop.ViewModels;

public class TablePageViewModel : PageViewModelBase
{
    public ObservableCollection<PageListItem> contents { get; } = 
    [
        new () { PageViewModel = new OrderPageViewModel(new OrderService())},
        new () { PageViewModel = new ClientPageViewModel(new ClientService())},
        new () { PageViewModel = new ItemPageViewModel(new ItemService())},
        new () { PageViewModel = new EquipmentPageViewModel(new EquipmentService())},
        new () { PageViewModel = new OperationPageViewModel(new OperationService())},
        new () { PageViewModel = new WorkerPageViewModel(new WorkerService())},
        new () { PageViewModel = new PersonPageViewModel(new PersonService())},
        new () { PageViewModel = new DepartmentPageViewModel(new DepartmentService())},
    ];
    [Reactive] public PageListItem selected_content { get; set; }
    public TablePageViewModel()
    {
        Title = "Таблицы";
        selected_content = contents[0];
    }
}