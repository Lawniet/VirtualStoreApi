using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;

namespace VirtualStoreApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, StoreDTO>();
            CreateMap<StockItem, StockItemDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Store, BaseEntityDTO>();
            CreateMap<Product, BaseEntityDTO>();
            CreateMap<StockItem, BaseEntityDTO>();
        }
    }
}
