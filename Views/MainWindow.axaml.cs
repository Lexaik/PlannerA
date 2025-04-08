using Avalonia.Controls;
using PlannerA.ViewModels;

namespace PlannerA.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}