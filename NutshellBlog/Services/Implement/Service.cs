using NutshellBlog.Models;
using NutshellBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutshellBlog.Services.Implement
{
    public abstract class Service<T>
        : IService<T>
        where T : Entity
    {
        protected IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public async Task<T> GetAsync(object id)
        {
            return await _repository.GetAsync(id);
        }

        public IQueryable<T> GetPagingEntities<S>(int pageIndex, int pageSize, out long totalCount, Expression<Func<T, bool>> where, Expression<Func<T, S>> order, bool isDesc = false)
        {
            return _repository.GetPagingEntities<S>(pageIndex, pageSize, out totalCount, where, order, isDesc);
        }

        public async Task<bool> SaveEntitiesAsync()
        {
            return await _repository.UnitOfWork.SaveEntitiesAsync();
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    }
}
