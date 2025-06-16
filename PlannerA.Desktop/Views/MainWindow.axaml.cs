using Avalonia.Controls;
using PlannerA.Desktop.ViewModels;

namespace PlannerA.Desktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}