using FLYR_Task_ConsoleApp.Interfaces;
using FLYR_Task_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLYR_Task_ConsoleApp.PriceRules
{
    public class PercentageDiscountRule : ICheckoutRule
    {
        private readonly string _productCode;
        private readonly int _minQuantity;
        private readonly decimal _discountPercentage;

        public PercentageDiscountRule(string productCode, int minQuantity, decimal discountPercentage)
        {
            _productCode = productCode;
            _minQuantity = minQuantity;
            _discountPercentage = discountPercentage;
        }

        public void ApplyPriceRule(List<CartItem> items)
        {
            var item = items.FirstOrDefault(i => i.Product.Code == _productCode);
            if (item != null && item.Quantity >= _minQuantity)
            {
                item.Product.Price *= _discountPercentage;
            }
        }
    }
}
