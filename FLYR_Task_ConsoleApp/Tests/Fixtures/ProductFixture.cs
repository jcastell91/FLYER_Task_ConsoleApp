
using FLYR_Task_ConsoleApp.Models;

namespace FLYR_Task_ConsoleApp.Tests.Fixtures
{

        public static class ProductFixtures
        {
            public static Product GreenTea => new Product("GR1", "Green Tea", 3.11m);
            public static Product Strawberries => new Product("SR1", "Strawberries", 5.00m);
            public static Product Coffee => new Product("CF1", "Coffee", 11.23m);
        }
    }


