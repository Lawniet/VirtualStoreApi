using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utils;
using Domain.Entities;

namespace Application.Services
{
    public interface IService<T> where T : BaseEntity
    {
        T GetById(int id);
        IApplicationResponse Save(T entity);
        IApplicationResponse Delete(T entity);
    }
}
