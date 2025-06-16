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

public class DepartmentPageViewModel : PageViewModelBase
{
    public ObservableCollection<Department> Departments { get; } = [];
    [Reactive] public Department? SelectedDepartment { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditDepartment { get; }
    private async Task LoadDepartmentsAsync(ICrudService<Department> crudService)
    {
        var departments = await crudService.GetAllAsync();
        Departments.Clear();
        foreach (var department in departments)
        {
            Departments.Add(department);
        }
    }
    public DepartmentPageViewModel(ICrudService<Department> crudService)
    {
        Title = "Подразделения";
        
        LoadDepartmentsAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedDepartment,
            vm => vm.SelectedDepartment,
            (p1, _) => p1 is not null);
        
        CommandEditDepartment = ReactiveCommand.Create(() =>
        {
            var client = SelectedDepartment; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Client = client;*/
        }, canEdit);
    }
}