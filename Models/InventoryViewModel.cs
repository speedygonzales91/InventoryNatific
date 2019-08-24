using System.Collections.Generic;

namespace InventoryNatific.Models
{
    public class InventoryViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Inventory Inventory { get; set; }
    }
}