using Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLogic.Module._Common.QueryProvider
{
    public interface IBaseQueryProvider<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> wherePredict);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> wherePredict, bool asNoTracking);

        Task AddAsync(T entry);
        Task AddRangeAsync(IEnumerable<T> entries);
        Task SaveChangesAsync();
    }

    public abstract class BaseQueryProvider<T> where T: class
    {
        private readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseQueryProvider(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> wherePredict)
        {
            return await GetAsync(wherePredict, false);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> wherePredict, bool asNoTracking)
        {
            return await GetQuery(wherePredict, asNoTracking).ToListAsync();
        }

        protected IQueryable<T> GetQuery(Expression<Func<T, bool>> wherePredict, bool asNoTracking = false, Expression<Func<T, bool>> orderPredict = null, bool orderDesc = false)
        {
            var query = dbSet.Where(wherePredict);

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (orderPredict is not null)
            {
                if (orderDesc)
                {
                    query = query.OrderByDescending(orderPredict);
                } 
                else
                {
                    query = query.OrderBy(orderPredict);
                }
            }

            return query;
        }

        public async Task AddAsync(T entry)
        {
            await dbSet.AddAsync(entry);
        }

        public async Task AddRangeAsync(IEnumerable<T> entries)
        {
            await dbSet.AddRangeAsync(entries);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
