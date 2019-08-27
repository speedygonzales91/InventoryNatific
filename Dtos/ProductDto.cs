using System.ComponentModel.DataAnnotations;

namespace InventoryNatific.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1,double.MaxValue, ErrorMessage = "Please enter value greater than or equal to 1.")]
        public double Price { get; set; }

        public string Description { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter value greater than or equal to 0.01.")]
        public double Weight { get; set; }
    }
}