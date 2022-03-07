using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Validators
{
    public interface IStockItemValidator : IValidator<StockItem>
    {
        void Validate(StockOperation operation, StockItem stockItem);
    }
}
