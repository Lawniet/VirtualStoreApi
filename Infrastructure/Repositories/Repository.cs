using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _context;
    protected readonly DbSet<T> _entities;

    public Repository(DbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }
    public virtual bool Add(T entity)
    {
        if (entity == null)
            return false;

        _entities.Add(entity);

        _context.SaveChanges();

        return true;
    }

    public bool Delete(T entity)
    {
        if (entity == null)
            return false;

        _entities.Remove(entity);

        _context.SaveChanges();
        return true;
    }

    public virtual T GetById(int id)
    {
        return _entities.Find(id);
    }

    public bool Update(T entity)
    {
        if (entity == null)
            return false;

        _entities.Update(entity);

        _context.SaveChanges();
        return true;
    }
}
}
