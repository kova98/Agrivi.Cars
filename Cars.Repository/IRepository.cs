using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll(int page = 1, int pageSize = 10);
        T Get(long id);
        void Add(T entity);
        void Update(T entity);
        void Remove(long id);
    }
}
