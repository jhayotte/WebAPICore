using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApiCore.Infrastructure.Abstractions;

namespace WebApiCore.Repositories
{
    public abstract class Repository<TC, T> : IRepository<T>
            where T : class
            where TC : DbContext, new()
    {
        private readonly DbContext _context;

        private readonly DbSet<T> _dbSet;

        protected Repository()
        {
            _context = new TC();
            _dbSet = _context.Set<T>();
        }

        public virtual T Get<TKey>(TKey id)
        {
            return null;
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _dbSet;
            return query;
        }

        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _dbSet.Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public virtual void Delete<TKey>(TKey id)
        {
            Delete(Get(id));
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}