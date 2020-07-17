using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Repository
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
