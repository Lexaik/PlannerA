using System;

namespace PlannerA.Models;

public class Inventories
{
    public string Name { get; set; }
    public string Material { get; set; }
    public int Quantity { get; set; }
    public DateTime IntakeDate { get; set; }
    public string Price { get; set; }
}