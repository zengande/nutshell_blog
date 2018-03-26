using Microsoft.EntityFrameworkCore;
using NutshellBlog.Data;
using NutshellBlog.Infrastructure;
using NutshellBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NutshellBlog.Repositories.Implement
{
    public abstract class Repository<T>
        : IRepository<T>
        where T : Entity
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public T Add(T entity)
        {
            return _context.Set<T>()
                .Add(entity).Entity;
        }

        public async Task<T> GetAsync(object id)
        {
            return await _context.Set<T>()
                .FindAsync(id);
        }

        public IQueryable<T> GetPagingEntities<S>(int pageIndex, int pageSize, out long totalCount, Expression<Func<T, bool>> where, Expression<Func<T, S>> order, bool isDesc = false)
        {
            totalCount = _context.Set<T>().Where(where).LongCount();
            var items = _context.Set<T>()
                .Where(where)
                .OrderBy(order);
            if (isDesc)
            {
                items = items.OrderByDescending(order);
            }
            return items.Skip((1 - pageIndex) * pageSize)
                .Take(pageSize);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
