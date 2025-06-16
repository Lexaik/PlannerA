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

public class ItemPageViewModel : PageViewModelBase
{
    public ObservableCollection<Item> Items { get; } = [];
    [Reactive] public Item? SelectedItem { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditItem { get; }
    private async Task LoadItemsAsync(ICrudService<Item> crudService)
    {
        var items = await crudService.GetAllAsync();
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }
    public ItemPageViewModel(ICrudService<Item> crudService)
    {
        Title = "Склад";
        LoadItemsAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedItem,
            vm => vm.SelectedItem,
            (p1, _) => p1 is not null);
        
        CommandEditItem = ReactiveCommand.Create(() =>
        {
            var item = SelectedItem; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is NewOrderPageViewModel model) 
                model.Item = item;*/
        }, canEdit);
    }
}