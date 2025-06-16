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

public class ProcessPageViewModel : PageViewModelBase
{
    public ObservableCollection<Process> Processes { get; } = [];
    [Reactive] public Process? SelectedProcess { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditProcess { get; }
    private async Task LoadProcessesAsync(ICrudService<Process> crudService)
    {
        var processes = await crudService.GetAllAsync();
        Processes.Clear();
        foreach (var process in processes)
        {
            Processes.Add(process);
        }
    }
    public ProcessPageViewModel(ICrudService<Process> crudService)
    {
        Title = "Процессы";
        LoadProcessesAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedProcess,
            vm => vm.SelectedProcess,
            (p1, _) => p1 is not null);
        
        CommandEditProcess = ReactiveCommand.Create(() =>
        {
            var client = SelectedProcess; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Client = client;*/
        }, canEdit);
    }
}