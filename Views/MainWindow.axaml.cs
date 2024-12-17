using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Styling;
namespace PlannerA.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ApplyStyles();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void ApplyStyles()
    {

        var buttonStyle = new Style(x => x.OfType<Button>())
        {
            Setters =
            {
                new Setter(Button.FontFamilyProperty, new FontFamily("Verdana")),
                new Setter(Button.BackgroundProperty, Brushes.LightSteelBlue),
                new Setter(Button.ForegroundProperty, Brushes.Black),
                new Setter(Button.MarginProperty, new Thickness(0)),
               
            }
        };
               
        var labelStyle = new Style(x => x.OfType<Label>())
        {
            Setters =
            {
                new Setter(Label.FontFamilyProperty, new FontFamily("Verdana")),
                new Setter(Label.BackgroundProperty, Brushes.LightSkyBlue),
                new Setter(Label.ForegroundProperty, Brushes.Black),
                new Setter(Label.MarginProperty, new Thickness(0)), 
               
            }
        };

        this.Styles.Add(buttonStyle);
        this.Styles.Add(labelStyle);
    }
}

























/*
using Avalonia.Controls;

namespace PlannerA.Views;

public partial class MainWindow : Window
{
     
    public MainWindow()
    {
        InitializeComponent();
    }
}
*/