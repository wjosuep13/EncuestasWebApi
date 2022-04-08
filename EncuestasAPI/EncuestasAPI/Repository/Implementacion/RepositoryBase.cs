
using EncuestasAPI.Models;
using EncuestasAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace EncuestasAPI.Repository.Implementation
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryBase(EncuestasDbContext context)
        {
            _context = context;
        }
        public EncuestasDbContext _context { get; set; }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public virtual void AddRange(List<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            //context.Set<T>().Add(entity);
        }

        public virtual bool Exist(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable();
        }

     

        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().FirstOrDefault(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;

        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var data = _context.Set<T>().Where(predicate).ToList();
            _context.Set<T>().RemoveRange(data);
        }
    }
}
