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
    public class EfRepositoryBase<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity, new()
    {
        private readonly GoldfishAgendaDbContext _context;
        private readonly DbSet<TEntity> _entity;
        public EfRepositoryBase(GoldfishAgendaDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _entity.Add(entity);
            _context.SaveChanges();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? _entity.ToList()
                : _entity.Where(expression);
        }
        public TEntity GetById(int id) => _entity.Find(id);
        public IEnumerable<TEntity> GetAll() => _entity.ToList();
        public void Remove(TEntity entity)
        {
            _entity.Remove(entity);
            _context.SaveChanges();
        }
    }
}
