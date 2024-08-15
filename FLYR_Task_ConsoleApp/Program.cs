using FLYR_Task_ConsoleApp.Interfaces;
using FLYR_Task_ConsoleApp.Models;
using FLYR_Task_ConsoleApp.PriceRules;
using FLYR_Task_ConsoleApp.Services;
using System;
using System.Collections.Generic;


namespace FLYR_Task_ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Products 
            var products = new List<Product>
        {
            new Product("GR1", "Green tea", 3.11m),
            new Product("SR1", "Strawberries", 5.00m),
            new Product("CF1", "Coffee", 11.23m)
        };

            // Price Rules 
            var pricingRules = new List<ICheckoutRule>
        {
            new BuyOneGetOneFreeRule("GR1"),
            new BulkDiscountRule("SR1", 3, 4.50m),
            new PercentageDiscountRule("CF1", 3, 2m/3m)
        };

            // Dependency Inyection
            var checkout = new CheckoutService(pricingRules);

            // Simulate Scan Products using Input Data
            checkout.Scan(products[0]);
            checkout.Scan(products[1]);
            checkout.Scan(products[2]);
            checkout.Scan(products[2]);
            checkout.Scan(products[2]);

            // Answer Calculating Total
            var total = checkout.TotalPrice();
            Console.WriteLine($"Total: £{total:F2}");
            Console.ReadLine();
        }
    }

}
