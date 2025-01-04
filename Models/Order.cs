using System;
using System.Collections.Generic;

namespace PlannerA.Models;

public class Order
{
    public string Name { get; set; }
    public Dictionary<Item, int> Products;
    public DateTime DateStart;
    public DateTime PlaneDateExecute;

    public Order(string name, DateTime dateStart, DateTime planeDateExecute)
    {
        this.Name = name;
        Products = new Dictionary<Item, int>();
        this.DateStart = dateStart;
        this.PlaneDateExecute = planeDateExecute;
    }

    public void AddProducts(Item item, int quantity)
        {
            Products[item] = quantity;
        } 
}