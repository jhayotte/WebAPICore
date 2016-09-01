using System.Collections.Generic;

namespace WebApiCore.Infrastructure.BusinessLogic.Abstractions
{
    public interface IManager<T> where T : class
    {
        IList<T> GetAll();
        T Get<TKey>(TKey id);
        void Add(T entity);
        void Delete<TKey>(TKey id);
        void Update(T entity);
    }
}
