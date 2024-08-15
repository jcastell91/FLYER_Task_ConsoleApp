using FLYR_Task_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLYR_Task_ConsoleApp.Interfaces
{
    public interface ICheckoutRule
    {
        void ApplyPriceRule(List<CartItem> items);
    }
}
