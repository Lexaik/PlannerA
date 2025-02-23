using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;

namespace PlannerA.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
<<<<<<< HEAD
        // ApplyStyles();

#if DEBUG
        this.AttachDevTools();
#endif

    }

    
=======

>>>>>>> origin/TaskStyle1
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
                new Setter(FontFamilyProperty, new FontFamily("Verdana")),
                new Setter(BackgroundProperty, Brushes.LightSteelBlue),
                new Setter(ForegroundProperty, Brushes.Black),
                new Setter(MarginProperty, new Thickness(0))
            }
        };

        var labelStyle = new Style(x => x.OfType<Label>())
        {
            Setters =
            {
                new Setter(FontFamilyProperty, new FontFamily("Verdana")),
                new Setter(BackgroundProperty, Brushes.LightSkyBlue),
                new Setter(ForegroundProperty, Brushes.Black),
                new Setter(MarginProperty, new Thickness(0))
            }
        };

        Styles.Add(buttonStyle);
        Styles.Add(labelStyle);
    }
<<<<<<< HEAD

    private void AddNewComponentButton_Click(object sender, RoutedEventArgs e)
    {
        var selectedItem = MaterialsList.SelectedItem as ListBoxItem;
        if (selectedItem != null)
        {
            // Логика использования в диаграмме
            // MessageBox.Show($"Использование в диаграмме: {selectedItem.Content}");
        }
    } 
    
=======
>>>>>>> origin/TaskStyle1
}

/*
using Avalonia.Controls;

namespace PlannerA.Views;

public partial class MainWindow : Window
{


}
*/