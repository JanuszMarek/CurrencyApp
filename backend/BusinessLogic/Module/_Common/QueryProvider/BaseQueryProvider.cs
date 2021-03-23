using Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module._Common.QueryProvider
{
    public interface IBaseQueryProvider<T> where T : class
    {
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
