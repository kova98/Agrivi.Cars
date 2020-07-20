using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cars.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            int page = 1, 
            int pageSize = 10);
        T Get(long id);
        void Add(T entity);
        void Update(T entity);
        void Remove(long id);
    }
}
