using ReactiveUI.Fody.Helpers;

namespace PlannerA.Desktop.ViewModels;

public class PageListItem
{
    [Reactive] public PageViewModelBase PageViewModel{ get; set; }
    public string Title => PageViewModel.Title;
}