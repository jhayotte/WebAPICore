using System.Collections.Generic;
using System.Linq;
using WebApiCore.Infrastructure.Abstractions;
using WebApiCore.Infrastructure.BusinessLogic.Abstractions;

namespace WebApiCore.Infrastructure.BusinessLogic
{
    public abstract class Manager<TR, T> : IManager<T>
            where T : class
            where TR : IRepository<T>, new()
    {
        private readonly IRepository<T> _repository;

        protected Manager()
        {
            _repository = new TR();
        }

        public virtual T Get<TKey>(TKey id)
        {
            return _repository.Get(id);
        }

        public virtual IList<T> GetAll()
        {

            IQueryable<T> entities = _repository.GetAll();

            return entities.ToList();
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Delete<TKey>(TKey id)
        {
            _repository.Delete(id);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}