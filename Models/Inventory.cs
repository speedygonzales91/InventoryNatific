using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryNatific.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select valid Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}