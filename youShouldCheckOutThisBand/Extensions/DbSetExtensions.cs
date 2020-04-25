
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;



namespace youShouldCheckOutThisBand.Extensions
{
    public static class DbSetExtensions
    {
        /// <summary>
        /// Adds an item to a context if it doesnt already exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="entity"></param>
        /// <param name="predicate"></param>
        public static void AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            if (!exists)
            {
                dbSet.Add(entity);
            }

            //example
            //public void DoSomeContextWork(DbContext context)
            //{
            //    var uni = new Unicorn();
            //    context.Set<Unicorn>().AddIfNotExists(uni, x => x.Name == "James");
            //}
        }
    }
}
