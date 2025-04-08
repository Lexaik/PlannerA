using System.Collections.Generic;
using PlannerA.Models;

namespace PlannerA.ViewModels;

public class DataRow(string x)
{
    public string name { get; set ; }= x;
    public List<string> status { get; set; }
}