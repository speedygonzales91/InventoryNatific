using AutoMapper;
using InventoryNatific.Dtos;
using InventoryNatific.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryNatific.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();

            Mapper.CreateMap<InventoryElement, InventoryElementDto>();
            Mapper.CreateMap<InventoryElementDto, InventoryElement>();
        }
    }
}