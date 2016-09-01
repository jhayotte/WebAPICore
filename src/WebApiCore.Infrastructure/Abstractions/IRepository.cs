using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebApiCore.Infrastructure.Abstractions
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get<TKey>(TKey id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete<TKey>(TKey id);
        void Delete(T entity);
        void Update(T entity);
    }
}
