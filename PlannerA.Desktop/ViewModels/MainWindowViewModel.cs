using System.Collections.ObjectModel;
using System.Reactive;
using PlannerA.BLL;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PlannerA.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PageListItem> Pages { get; } = 
    [
        new () { PageViewModel = new PlanPageViewModel()},
        new () { PageViewModel = new TablePageViewModel()},
        new () { PageViewModel = new NewOrderPageViewModel()},
    ];
    [Reactive] public PageListItem SelectedPage { get; set; }
    
    [Reactive] public bool IsPaneOpen { get; set; }
    
    public ReactiveCommand<Unit, bool> CommandPaneOpenClose { get; }

    [Reactive] public string pic { get; set; }

    public MainWindowViewModel()
    {
        SelectedPage = Pages[0];
        
        IsPaneOpen = false;
        pic = "->";

        CommandPaneOpenClose = ReactiveCommand.Create(() =>
        {
            IsPaneOpen = !IsPaneOpen;
            pic = IsPaneOpen ? "<-" : "->" ;
            return IsPaneOpen;
        });
    }
}
            