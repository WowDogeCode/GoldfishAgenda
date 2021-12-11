using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EfRepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _entity;
        public EfRepositoryBase(DbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }
        public void Add(T entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? _entity.ToList()
                : _entity.Where(expression);
        }
        public T GetById(int id) => _entity.Find(id);
        public IEnumerable<T> GetAll() => _entity.ToList();
        public void Remove(T entity)
        {
            _entity.Remove(entity);
            _context.SaveChanges();
        }
    }
}
