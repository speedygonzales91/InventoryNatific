using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryNatific.Models
{
    [Table("Inventory")]
    public class InventoryElement
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Amount { get; set; }
    }
}