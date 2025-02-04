using System.Collections.Generic;

namespace PlannerA.ViewModels;

public class DataRow
{
    public required string name { get; set ; }
    public List<string> status { get; set; }

    public DataRow(string x)
    {
        name = x;
    }
}