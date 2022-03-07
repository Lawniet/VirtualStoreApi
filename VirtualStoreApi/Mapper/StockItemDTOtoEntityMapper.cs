using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;

namespace VirtualStoreApi.Mapper
{
    public static class StockItemDTOtoEntityMapper
    {
        public static StockItem ToEntity(this StockItemDTO dto)
        {
            var stockItem = new StockItem
            {
                Id = dto.Id,
                ProductId = dto.ProductId,
                StoreId = dto.StoreId,
                Quantity = dto.Quantity
            };
            return stockItem;
        }
    }
}
