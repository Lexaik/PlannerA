using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Media;
using Avalonia.Styling;
namespace PlannerA.Views;

using Avalonia.Interactivity;
using System.Collections.Generic;

public partial class MainWindow : Window
{
    private ListBox _listBox;
    private TextBox _textBox;
    private Button _addButton;
    private Button _editButton;
    private Button _deleteButton;
    private Button _useButton;

    private List<string> _items = new List<string>();

    public object MessageBox { get; private set; }

    public MainWindow()
    {
        InitializeComponent();
        // ApplyStyles();

        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

    }


    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void SelectButton_Click(object sender, RoutedEventArgs e)
{
    var selectedItem = MaterialsList.SelectedItem as ListBoxItem;
    if (selectedItem != null)
    {
            // Действие для выбранного элемента
           // MessageBox.Show($"Вы выбрали: {selectedItem.Content}");
    }
}

private void EditButton_Click(object sender, RoutedEventArgs e)
{
    var selectedItem = MaterialsList.SelectedItem as ListBoxItem;
    if (selectedItem != null)
    {
        // Логика редактирования выбранного элемента
        //MessageBox.Show($"Редактирование: {selectedItem.Content}");
    }
}

private void DeleteButton_Click(object sender, RoutedEventArgs e)
{
    var selectedItem = MaterialsList.SelectedItem as ListBoxItem;
    if (selectedItem != null)
    {
        MaterialsList.Items.Remove(selectedItem);
        // Уведомление об удалении
        //MessageBox.Show($"Удалено: {selectedItem.Content}");
    }
}

private void UseInDiagramButton_Click(object sender, RoutedEventArgs e)
{
    var selectedItem = MaterialsList.SelectedItem as ListBoxItem;
    if (selectedItem != null)
    {
        // Логика использования в диаграмме
       // MessageBox.Show($"Использование в диаграмме: {selectedItem.Content}");
    }
}

}
    
