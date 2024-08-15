namespace CheckOutApp.Tests
{
    using FLY.Models;
    using CheckoutApp.Services;
    using CheckoutApp.Rules;
    using System;
    using System.Collections.Generic;
    using Xunit;

    namespace CheckoutApp.Tests
    {
        public class CheckoutTests
        {
            [Fact]
            public void Scan_NullProduct_ThrowsArgumentNullException()
            {
                // Arrange
                var rules = new List<ICheckoutRule>();
                var checkout = new Checkout(rules);

                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => checkout.Scan(null));
            }

            [Fact]
            public void Total_EmptyCart_ThrowsInvalidOperationException()
            {
                // Arrange
                var rules = new List<ICheckoutRule>();
                var checkout = new Checkout(rules);

                // Act & Assert
                Assert.Throws<InvalidOperationException>(() => checkout.Total());
            }

            [Fact]
            public void Checkout_NullPricingRules_ThrowsArgumentNullException()
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => new Checkout(null));
            }
        }
    }

}