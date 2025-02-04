using System;
using System.Collections.Generic;

namespace PlannerA.Models;

public class Order
{
    public required string name { get; set; }
    public DateOnly date_start { get; set; }
    public DateOnly date_end { get; set; }
    public Dictionary<Item, int> products;

    /*public Order(string Name, DateOnly start, DateOnly end)
    {
        name = Name;
        products = new Dictionary<Item, int>();
        date_start = start;
        date_end = end;
    }*/
    public void AddProducts(Item item, int quantity)
    {
        products[item] = quantity;
    }
}