using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PlannerA.Desktop.Components;

public partial class DateInputComponent : UserControl
{
    public static readonly StyledProperty<object?> LabelContentProperty = 
        AvaloniaProperty.Register<DateInputComponent, object?>(nameof(LabelContent));
    public static readonly StyledProperty<DateTimeOffset?> InputDateProperty = 
        AvaloniaProperty.Register<DateInputComponent, DateTimeOffset?>(nameof(SelectedDate));
    public DateTimeOffset? SelectedDate
    {
        get => GetValue(InputDateProperty);
        set => SetValue(InputDateProperty, value);
    }
    public object? LabelContent
    {
        get => GetValue(LabelContentProperty); 
        set => SetValue(LabelContentProperty, value);
    }
    public DateInputComponent()
    {
        InitializeComponent();
    }
}