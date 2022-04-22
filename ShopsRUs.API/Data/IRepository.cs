using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopsRUs.API.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void AddRange(List<T> entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Find(bool trackChanges = false);
        IQueryable<T> Find(Expression<Func<T, bool>> expression, bool trackChanges = false);
    }
}
