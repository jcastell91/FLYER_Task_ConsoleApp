using FLYR_Task_ConsoleApp.Interfaces;
using FLYR_Task_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLYR_Task_ConsoleApp.PriceRules
{
    public class BuyOneGetOneFreeRule : ICheckoutRule
    {
        private readonly string _productCode;

        public BuyOneGetOneFreeRule(string productCode)
        {
            _productCode = productCode;
        }

        public void ApplyPriceRule(List<CartItem> items)
        {
            var item = items.FirstOrDefault(i => i.Product.Code == _productCode);
            if (item != null && item.Quantity > 1)
            {
                item.Quantity += item.Quantity / 2; // Each 2 items get 1 free
            }
        }
    }
}
