// Asegúrate de importar el namespace
using System;
using System.Collections.Generic;
using Xunit;
using FLYR_Task_ConsoleApp.Interfaces;
using FLYR_Task_ConsoleApp.PriceRules;
using FLYR_Task_ConsoleApp.Services;
using FLYR_Task_ConsoleApp.Tests.Fixtures;

namespace CheckoutApp.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void Scan_NullProduct_ThrowsArgumentNullException()
        {
          
            var rules = new List<ICheckoutRule>();
            var checkout = new CheckoutService(rules);

            Assert.Throws<ArgumentNullException>(() => checkout.Scan(null));
        }

        [Fact]
        public void Total_EmptyCart_ThrowsInvalidOperationException()
        {
            var rules = new List<ICheckoutRule>();
            var checkout = new CheckoutService(rules);

            Assert.Throws<InvalidOperationException>(() => checkout.TotalPrice());
        }

        [Fact]
        public void Checkout_NullPricingRules_ThrowsArgumentNullException()
        {
   
            Assert.Throws<ArgumentNullException>(() => new CheckoutService(null));
        }

        [Fact]
        public void Total_WithValidProducts_ReturnsExpectedTotal1()
        {

            var rules = new List<ICheckoutRule>
            {
                new BuyOneGetOneFreeRule(ProductFixtures.GreenTea.Code),
                new BulkDiscountRule(ProductFixtures.Strawberries.Code, 3, 4.50m),
                new PercentageDiscountRule(ProductFixtures.Coffee.Code, 3, 2m / 3m)
            };

            var checkout = new CheckoutService(rules);

            // Act
            checkout.Scan(ProductFixtures.GreenTea);      // GR1
            checkout.Scan(ProductFixtures.Strawberries);  // SR1       
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1

            // Assert
            var total = checkout.TotalPrice();
            Assert.Equal(30.57m, total);
        }

        public void Total_WithValidProducts_ReturnsExpectedTotal2()
        {

            var rules = new List<ICheckoutRule>
            {
                new BuyOneGetOneFreeRule(ProductFixtures.GreenTea.Code),
                new BulkDiscountRule(ProductFixtures.Strawberries.Code, 3, 4.50m),
                new PercentageDiscountRule(ProductFixtures.Coffee.Code, 3, 2m / 3m)
            };

            var checkout = new CheckoutService(rules);

            // Act
            checkout.Scan(ProductFixtures.GreenTea);      // GR1
            checkout.Scan(ProductFixtures.Strawberries);  // SR1
            checkout.Scan(ProductFixtures.Strawberries);  // SR1
            checkout.Scan(ProductFixtures.Strawberries);  // SR1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1

            // Assert
            var total = checkout.TotalPrice();
            Assert.Equal(39.07m, total);
        }

        public void Total_WithValidProducts_ReturnsExpectedTotal3()
        {

            var rules = new List<ICheckoutRule>
            {
                new BuyOneGetOneFreeRule(ProductFixtures.GreenTea.Code),
                new BulkDiscountRule(ProductFixtures.Strawberries.Code, 3, 4.50m),
                new PercentageDiscountRule(ProductFixtures.Coffee.Code, 3, 2m / 3m)
            };

            var checkout = new CheckoutService(rules);

            // Act
            checkout.Scan(ProductFixtures.GreenTea);      // GR1
            checkout.Scan(ProductFixtures.GreenTea);      // GR1
            checkout.Scan(ProductFixtures.GreenTea);      // GR1
            checkout.Scan(ProductFixtures.Strawberries);  // SR1
            checkout.Scan(ProductFixtures.Strawberries);  // SR1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1
            checkout.Scan(ProductFixtures.Coffee);        // CF1

            // Assert
            var total = checkout.TotalPrice();
            Assert.Equal(39.07m, total);
        }
    }
}
