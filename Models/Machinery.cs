using System.Collections.Generic;

namespace PlannerA.Models;

public class Machinery
{
    public string name { get; set; }
    public string type { get; set; }
    public List <Operation>? loading;
   
}