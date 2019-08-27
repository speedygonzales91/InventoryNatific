using InventoryNatific.Dtos;
using System.Collections.Generic;

namespace InventoryNatific.ViewModels
{
    public class InventoryEditViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }

        public InventoryElementDto InventoryElement { get; set; }
    }
}