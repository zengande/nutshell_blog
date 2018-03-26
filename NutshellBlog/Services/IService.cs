using NutshellBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutshellBlog.Services
{
    public interface IService<T>
    {
        T Add(T entity);

        void Update(T entity);

        Task<T> GetAsync(object id);

        Task<bool> SaveEntitiesAsync();

        IQueryable<T> GetPagingEntities<S>(int pageIndex, int pageSize, out long totalCount, Expression<Func<T, bool>> where, Expression<Func<T, S>> order, bool isDesc = false);
    }
}
