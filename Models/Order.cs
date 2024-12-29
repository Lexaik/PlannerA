using System;
using System.Collections.Generic;

namespace PlannerA.Models;

public class Order
{
    public string name { get; set; }
    public Dictionary<Item, int> products;
    public DateTime date_start;
    public DateTime date_execute;

    public Order(string name, DateTime date_start, DateTime date_execute)
    {
        this.name = name;
        products = new Dictionary<Item, int>();
        this.date_start = date_start;
        this.date_execute = date_execute;
    }

    public void addProducts(Item item, int quantity)
        {
            products[item] = quantity;
        } 
}