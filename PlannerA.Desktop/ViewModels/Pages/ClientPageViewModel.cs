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

public class ClientPageViewModel : PageViewModelBase
{
    public ObservableCollection<Client> Clients { get; } = [];
    [Reactive] public Client? SelectedClient { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditClient { get; }
    private async Task LoadClientsAsync(ICrudService<Client> crudService)
    {
        var clients = await crudService.GetAllAsync();
        Clients.Clear();
        foreach (var client in clients)
        {
            Clients.Add(client);
        }
    }
    public ClientPageViewModel(ICrudService<Client> crudService)
    {
        Title = "Клиенты";
        LoadClientsAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedClient,
            vm => vm.SelectedClient,
            (p1, _) => p1 is not null);
        
        CommandEditClient = ReactiveCommand.Create(() =>
        {
            var client = SelectedClient; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model)
                model.Client = client;*/
        }, canEdit);
    }
}