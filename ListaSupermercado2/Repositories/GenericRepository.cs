using ListaSupermercado2.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ListaSupermercado2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ListaSupermercadoContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(ListaSupermercadoContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var categoria = _dbSet.Find(id);
            _dbSet.Remove(categoria);
        }

        public ICollection<T> List()
        {
            return _dbSet.ToList();
        }

        public T SearchById(int id)
        {
            return _dbSet.Find(id);
        }

        public ICollection<T> SearchFor(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }
    }
}