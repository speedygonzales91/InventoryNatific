using System.ComponentModel.DataAnnotations;

namespace InventoryNatific.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }
    }
}