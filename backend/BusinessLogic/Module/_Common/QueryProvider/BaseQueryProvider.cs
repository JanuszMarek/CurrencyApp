using Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Module._Common.QueryProvider
{
    public abstract class BaseQueryProvider<T> where T: class
    {
        private readonly DbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseQueryProvider(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async void AddAsync(T entry)
        {
            await dbSet.AddAsync(entry);
        }

        public async void AddRangeAsync(IEnumerable<T> entries)
        {
            await dbSet.AddRangeAsync(entries);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
