using System;

namespace PlannerA.Models;

public abstract class Project
{
    public Guid Id { get; set; }
    public Client client { get; set; }
    public Item product { get; set; }
    public int Quantity  { get; set; }
    public bool IsActive { get; set; }
    public DateTime FinishPlanDate { get; set; }
}