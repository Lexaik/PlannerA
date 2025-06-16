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

public class OperationPageViewModel : PageViewModelBase
{
    public ObservableCollection<Operation> Operations { get; } = [];
    [Reactive] public Operation? SelectedOperation { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditOperation { get; }
    private async Task LoadOperationsAsync(ICrudService<Operation> crudService)
    {
        var operations = await crudService.GetAllAsync();
        Operations.Clear();
        foreach (var operation in operations)
        {
            Operations.Add(operation);
        }
    }
    public OperationPageViewModel(ICrudService<Operation> crudService)
    {
        Title = "Операции";
        LoadOperationsAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedOperation,
            vm => vm.SelectedOperation,
            (p1, _) => p1 is not null);
        
        CommandEditOperation = ReactiveCommand.Create(() =>
        {
            var client = SelectedOperation; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Client = client;*/
        }, canEdit);
    }
}