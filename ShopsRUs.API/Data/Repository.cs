using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopsRUs.API.Data
{
    public partial class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll() => _context.Set<T>().ToList();

        public virtual T GetById(int id) => _context.Set<T>().Find(id);

        public virtual async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public virtual IQueryable<T> Find(bool trackChanges = false) =>
            trackChanges ? _context.Set<T>()
                         : _context.Set<T>().AsNoTracking();

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
            trackChanges ? _context.Set<T>().Where(expression)
                         : _context.Set<T>().Where(expression).AsNoTracking();
    }
}
