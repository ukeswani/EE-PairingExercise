using System;
using System.Collections.Generic;
using System.Linq;

namespace EE_SuperMarket
{
    public class SuperMarket
    {
        public static double CalculateTotalCost(int numberOfItems, double costPerItem)
        {
            return numberOfItems * costPerItem;
        }

        public static double CalculateTotalCost(List<ItemHolder> items)
        {
            return items.Select(i => CalculateTotalCost(i.NumberOfItems, i.CostPerItem)).Sum();
        }

        public static Func<double, double> CalculateServiceTax(double serviceTax)
        {
            return amount =>
            {
                var taxAmount = amount * serviceTax/100;
                return amount + taxAmount;
            };
        }
    }
}
