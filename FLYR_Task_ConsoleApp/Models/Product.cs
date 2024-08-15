using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLYR_Task_ConsoleApp.Models
{
    public class Product
    {
            public string Code { get; }
            public string Name { get; }
            public decimal Price { get; set; }

            public Product(string code, string name, decimal price)
            {
                Code = code;
                Name = name;
                Price = price;
            }
        }
    }
 
