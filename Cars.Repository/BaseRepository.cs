using Cars.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cars.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        internal ApplicationDbContext context;
        internal DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int page = 1,
            int pageSize = 10,
            params Expression<Func<T, object>>[] include)
        {
            var query = dbSet.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            if (include != null)
            {
                include.ToList().ForEach(include =>
                {
                    if (include != null)
                    {
                        query = query.Include(include);
                    }
                });
            } 

            var result = query.ToList();

            return result;
        }

        public virtual T Get(long id)
        {
            var entity = dbSet.FirstOrDefault(x => x.Id == id);

            return entity;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);

            context.SaveChanges();
        }

        public virtual void Remove(long id)
        {
            var entityToRemove = dbSet.FirstOrDefault(x => x.Id == id);

            if (context.Entry(entityToRemove).State == EntityState.Detached)
            {
                dbSet.Attach(entityToRemove);
            }

            dbSet.Remove(entityToRemove);

            context.SaveChanges();
        }

        public virtual void Update(T entityToUpdate)
        {
            dbSet.Update(entityToUpdate);
            context.SaveChanges();
        }

    }
}
