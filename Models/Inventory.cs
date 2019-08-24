using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryNatific.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}