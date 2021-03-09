using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Entity.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedEntityData<TEntity>(this ModelBuilder modelBuilder, IEnumerable<TEntity> dataSeedCollection) where TEntity : class
        {
            foreach (var data in dataSeedCollection)
            {
                modelBuilder.Entity<TEntity>().HasData(data);
            }
        }
    }
}
