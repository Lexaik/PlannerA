using System;
using System.Collections.Generic;
namespace PlannerA.Models;
public class Order(string name, DateTime dateStart, DateTime dateEndPlan)
{
    public string name { get; set; } = name;
    public DateTime date_start { get; set; } = dateStart;
    public DateTime? date_end { get; set; }
    public DateTime date_end_plan { get; set; } = dateEndPlan;
    public Dictionary<Item, int> products { get; set; } = [];
    public void addProducts(Item item, int quantity)
    {
        products[item] = quantity;
    }
}