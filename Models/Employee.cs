using System;
using System.Runtime.InteropServices.JavaScript;

namespace PlannerA.Models;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime StartVacation { get; set; }
    public DateTime EndVacation { get; set; }
    public double Salary { get; set; }
    
}