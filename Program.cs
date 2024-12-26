using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Collections.Generic;
using PlannerA.Models;

namespace PlannerA;

abstract class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
    
    public Plant aurora = new Plant
    {
        name = "Aurora",
        employee = new List<Worker>
        {"Василий", "Андрей", "Александр", "Алексей", "Александр", "Алексей", "Александр", "Алексей", "Александр", "Алексей", "Александ},
        equipment = new List<Machinery>(),
        orders = new List<Order>(),
        inventories = new Dictionary<Item, int>(),
        
    };
}
