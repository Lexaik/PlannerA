using System;
using System.Collections.Generic;

namespace PlannerA.Models;

public class Order
{
    public string Name { get; set; }
    public DateTime DateStart;
    public DateTime PlaneDateExecute;
    public Dictionary<Item, int> Products;

    public Order(string name, DateTime dateStart, DateTime planeDateExecute)
    {
        Name = name;
        Products = new Dictionary<Item, int>();
        DateStart = dateStart;
        PlaneDateExecute = planeDateExecute;
    }
  
    public void AddProducts(Item item, int quantity)
    {
        Products[item] = quantity;
    }
    
    
}