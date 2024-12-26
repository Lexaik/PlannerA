using System;
using System.Collections.Generic;

namespace PlannerA.Models;

public abstract class Order
{
    public string name { get; set; }
    public Dictionary<Item, int> products;
    public DateTime date_start;
    public DateTime date_execute;
}