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

public class EquipmentPageViewModel : PageViewModelBase
{
    public ObservableCollection<Equipment> Equipments { get; } = [];
    [Reactive] public Equipment? SelectedEquipment { get; set; }
    public ReactiveCommand<Unit, Unit> CommandEditEquipment { get; }
    private async Task LoadEquipmentsAsync(ICrudService<Equipment> crudService)
    {
        var equipments = await crudService.GetAllAsync();
        Equipments.Clear();
        foreach (var equipment in equipments)
        {
            Equipments.Add(equipment);
        }
    }
    public EquipmentPageViewModel(ICrudService<Equipment> crudService)
    {
        Title = "Оборудование";
        LoadEquipmentsAsync(crudService).ConfigureAwait(false);
        var canEdit = this.WhenAnyValue(
            vm => vm.SelectedEquipment,
            vm => vm.SelectedEquipment,
            (p1, _) => p1 is not null);
        
        CommandEditEquipment = ReactiveCommand.Create(() =>
        {
            var client = SelectedEquipment; //FIX
            
            if ((Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)
                ?.MainWindow
                ?.DataContext is not MainWindowViewModel mainWindowViewModel) return;
            
            mainWindowViewModel.SelectedPage = mainWindowViewModel.Pages[1];
            /*if (mainWindowViewModel.SelectedPage.PageViewModel is EditPageViewModel model) 
                model.Client = client;*/
        }, canEdit);
    }
}