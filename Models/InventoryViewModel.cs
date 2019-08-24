using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryNatific.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Inventory Inventory { get; set; }
    }
}