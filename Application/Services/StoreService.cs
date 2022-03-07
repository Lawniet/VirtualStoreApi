using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;
using Application.Validators;
using Domain.Entities;

namespace Application.Services
{
    public class StoreService : BaseService<Store>
    {
        public StoreService(IValidator<Store> validator, IRepository<Store> repository)
            : base(validator, repository)
        {
        }
    }
}
