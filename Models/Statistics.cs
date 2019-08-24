using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryNatific.Models
{
    public class Statistics
    {
        public double TotalWeight { get; set; }

        public double TotalSum { get; set; }

        public KeyValuePair<Product, int> MaxNumberOfProductInInventory { get; set; }

        public KeyValuePair<Product, double> MaxWeightOfProductInInventory { get; set; }
    }
}