using System;
using System.Collections.Generic;
using PlannerA.Models;

namespace PlannerA;

public class DataContent
{
public string work = "слесарь";
List<Workers> foundWorker = aurora.Employee.Where(x => x.Name.Contains(work)).ToList();
string search_opp = "Токарная";
List<string> resultOpp = aurora.Orders.SelectMany(a => a.Products)
    .SelectMany(b => b.Key.Process)
    .SelectMany(c => c.Type).ToList();
}