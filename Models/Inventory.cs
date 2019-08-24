using System.ComponentModel.DataAnnotations;

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