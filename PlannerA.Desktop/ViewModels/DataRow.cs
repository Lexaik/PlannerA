using System.Collections.Generic;

namespace PlannerA.Desktop.ViewModels;

public class DataRow(string x)
{
    public string name { get; set ; }= x;

    public List<string> status { get; set; } = [];
}