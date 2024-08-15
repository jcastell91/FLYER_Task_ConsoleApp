using FLYR_Task_ConsoleApp.Interfaces;
using FLYR_Task_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLYR_Task_ConsoleApp.Services
{
    public class CheckoutService
    {
         private readonly List<ICheckoutRule> _pricingRules;
            private readonly List<CartItem> _items;

            public CheckoutService(List<ICheckoutRule> pricingRules)
            {
                _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
                _items = new List<CartItem>();
            }

            public void Scan(Product product)
            {
                if (product == null)
                    throw new ArgumentNullException(nameof(product), "Product cannot be null.");

                var item = _items.FirstOrDefault(i => i.Product.Code == product.Code);
                if (item != null)
                {
                    item.Quantity++;
                }
                else
                {
                    _items.Add(new CartItem(product, 1));
                }
            }

            public decimal TotalPrice()
            {
                foreach (var rule in _pricingRules)
                {
                    rule.ApplyPriceRule(_items);
                }

                if (_items.Count == 0)
                    throw new InvalidOperationException("No items in the cart.");

                return _items.Sum(i => i.TotalPrice);
            }
        }
    
}


