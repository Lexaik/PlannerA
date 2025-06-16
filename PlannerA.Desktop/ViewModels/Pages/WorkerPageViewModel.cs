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

public class WorkerPageViewModel : PageViewModelBase
{
    public ObservableCollection<Worker> Workers { get; } = [];
    [Reactive] public Worker? SelectedWorker { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditWorker { get; }
    private async Task LoadWorkersAsync(ICrudService<Worker> crudService)
    {
        var workers = await crudService.GetAllAsync();
        Workers.Clear();
        foreach (var worker in workers)
        {
            Workers.Add(worker);
        }
    }
    public WorkerPageViewModel(ICrudService<Worker> crudService)
    {
        Title = "Персонал";
        LoadWorkersAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedWorker,
            vm => vm.SelectedWorker,
            (p1, _) => p1 is not null);
        
        CommandEditWorker = ReactiveCommand.Create(() =>
        {
            var client = SelectedWorker; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Client = client;*/
        }, canEdit);
    }
}