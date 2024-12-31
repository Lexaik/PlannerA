using Avalonia;
using Avalonia.ReactiveUI;
using System;
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
    
   Factory aurora = new Factory("Aurora");
   Worker worker1 = new Worker("Василий Васильев", "Токарь");
   Worker worker2 = new Worker("Иван Иванов", "Фрезеровщик");
   Worker worker3 = new Worker("Сергей Сергеев", "Сварщик");
   Worker worker4 = new Worker("Александр Александров", "Слесарь");
   Worker worker5 = new Worker("Андрей Андреев", "Слесарь");
   
   Machinery machinery1 = new Machinery("16К20", "токарный");
   Machinery machinery2 = new Machinery("ВМ125м", "фрезерный");
   Machinery machinery3 = new Machinery("Ресанта 250А", "Сварочный аппарат");
   Machinery machinery4 = new Machinery("Набор ключей", "Слесарный инструмент");
   Machinery machinery5 = new Machinery("", "Слесарный инструмент");
  
   aurora.addEmployee(worker1);
   Factory factory1 = new Factory("Нефтемаш");
   factory1.addEmloyee(worker2);
  
}
