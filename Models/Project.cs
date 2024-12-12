using System;

namespace PlannerA.Models;

public abstract class Project
{
    public Guid Id { get; set; }
    public string Client { get; set; }
    public string item { get; set; }
    public int Quantity  { get; set; }
    public bool IsActive { get; set; }
}