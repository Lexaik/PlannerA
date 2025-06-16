using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PlannerA.BLL;
using PlannerA.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PlannerA.Desktop.ViewModels;

public class OrderPageViewModel : PageViewModelBase
{
    public ObservableCollection<Order> Orders { get; } = [];
    [Reactive] public Order? SelectedOrder { get; set; }
    public ReactiveCommand<Unit, Unit> CommandCreateOrder { get; }
    public ReactiveCommand<Unit, Unit> CommandEditOrder { get; }
    public ReactiveCommand<Unit, Unit> CommandCopyOrder { get; }
    public ReactiveCommand<Unit, Unit> CommandDeleteOrder { get; }
    private async Task LoadOrdersAsync(ICrudService<Order> crudService)
    {
        var orders = await crudService.GetAllAsync();
        Orders.Clear();
        foreach (var order in orders)
        {
            Orders.Add(order);
        }
    }
    public OrderPageViewModel(ICrudService<Order> crudService)
    {
        Title = "Заказы";
        LoadOrdersAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedOrder,
            vm => vm.SelectedOrder,
            (p1, _) => p1 is not null);
        
        CommandCreateOrder = ReactiveCommand.Create(() =>
            {
                var order = new Order();

                if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                    ?.MainWindow
                    ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;

                mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
                if (mainWindowViewModel.SelectedPage.PageViewModel is NewOrderPageViewModel model)
                    model.order = order;
            },
            canEdit);
        CommandEditOrder = ReactiveCommand.Create(() =>
            {
                var order = SelectedOrder;

                if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                    ?.MainWindow
                    ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;

                mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[2];
                if (mainWindowViewModel.SelectedPage.PageViewModel is NewOrderPageViewModel model)
                    model.order = order;
            },
            canEdit);
        CommandCopyOrder = ReactiveCommand.Create(() =>
            {
                var order = SelectedOrder;

                if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                    ?.MainWindow
                    ?.DataContext is not MainWindowViewModel mainWindowViewModel)
                    return;

                mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
                if (mainWindowViewModel.SelectedPage.PageViewModel is NewOrderPageViewModel model)
                    model.order = order;
            },
            canEdit);
        CommandDeleteOrder = ReactiveCommand.Create(() =>
            {
                var order = SelectedOrder;

                if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                    ?.MainWindow
                    ?.DataContext is not MainWindowViewModel mainWindowViewModel)
                    return;

                mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
                if (mainWindowViewModel.SelectedPage.PageViewModel is NewOrderPageViewModel model)
                    model.order = order;
            },
            canEdit);
    }
}