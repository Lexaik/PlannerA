using System;
using System.Collections.Generic;
namespace PlannerA.Models;
public class Order(string name, DateOnly dateStart, DateOnly dateEnd)
{
    public required string name { get; set; } = name;
    public DateOnly date_start { get; set; } = dateStart;
    public DateOnly date_end { get; set; } = dateEnd;
    public Dictionary<Item, int> products { get; set; } = [];

    public void addProducts(Item item, int quantity)
    {
        products[item] = quantity;
    }
}