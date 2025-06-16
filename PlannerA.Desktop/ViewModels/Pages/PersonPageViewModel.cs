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

public class PersonPageViewModel : PageViewModelBase
{
    public ObservableCollection<Person> Persons { get; } = [];
    [Reactive] public Person? SelectedPerson { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditPerson { get; }
    private async Task LoadPersonsAsync(ICrudService<Person> crudService)
    {
        var persons = await crudService.GetAllAsync();
        Persons.Clear();
        foreach (var person in persons)
        {
            Persons.Add(person);
        }
    }
    public PersonPageViewModel(ICrudService<Person> crudService)
    {
        Title = "Люди";
        LoadPersonsAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedPerson,
            vm => vm.SelectedPerson,
            (p1, _) => p1 is not null);
        
        CommandEditPerson = ReactiveCommand.Create(() =>
        {
            var client = SelectedPerson; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Client = client;*/
        }, canEdit);
    }
}