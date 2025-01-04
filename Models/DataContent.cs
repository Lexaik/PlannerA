using System;
using System.Collections.Generic;
namespace PlannerA;

public class DataContent
{
    public static string searchParam = "точение";
    var foundInst = Factory.aurora.orders.Where(a => a.Products.Conteins(searchParam));

}
