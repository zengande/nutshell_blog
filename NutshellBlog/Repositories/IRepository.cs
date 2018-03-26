using NutshellBlog.Infrastructure;
using NutshellBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutshellBlog.Repositories
{
    public interface IRepository<T>
        where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        T Add(T entity);

        void Update(T entity);

        Task<T> GetAsync(object id);

        IQueryable<T> GetPagingEntities<S>(int pageIndex, int pageSize, out long totalCount, Expression<Func<T, bool>> where, Expression<Func<T, S>> order, bool isDesc = false);
    }
}
