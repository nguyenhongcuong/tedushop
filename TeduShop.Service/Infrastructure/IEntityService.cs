using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TeduShop.Service.Infrastructure
{
    public interface IEntityService<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        T Delete(T entity);
        T Delete(int id);
        IEnumerable<T> Get(string[] includes = null);
        IEnumerable<T> GetPaging(Expression<Func<T, bool>> expression, int pageIndex, int pageSize, out int totalRow);

        T Get(int id);
        void Commit();
    }
}
