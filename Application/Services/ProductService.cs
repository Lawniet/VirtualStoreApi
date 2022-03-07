using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Validators;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class ProductService : BaseService<Product>
    {
        public ProductService(IValidator<Product> validator, IRepository<Product> repository)
            : base(validator, repository)
        {
        }
    }
}
