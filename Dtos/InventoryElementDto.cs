using AutoMapper;
using InventoryNatific.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryNatific.Dtos
{
    public class InventoryElementDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select valid Product")]
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int Amount { get; set; }
    }
}