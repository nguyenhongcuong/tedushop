using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TeduShop.Data.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private TeduShopDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; }

        protected TeduShopDbContext DbContext =>
            _dbContext ?? (_dbContext = DbFactory.Init());

        protected Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }
        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public T Delete(int id)
        {
            var entity = _dbSet.Find(id);
            return _dbSet.Remove(entity ?? throw new InvalidOperationException());
        }

        public void DeleteMulti(Expression<Func<T, bool>> expression)
        {
            IEnumerable<T> objects = _dbSet.Where(expression).AsEnumerable();
            _dbSet.RemoveRange(objects);
        }

        public T GetSingleById(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return _dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Any())
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsEnumerable();
            }

            return _dbSet.AsEnumerable();
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where(expression).AsEnumerable();
            }

            return _dbSet.Where(expression).AsEnumerable();
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index = 0, int size = 50,
            string[] includes = null)
        {
            int skipCount = index * size;
            IEnumerable<T> resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = _dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                resetSet = expression != null ? query.Where(expression).AsEnumerable() : query.AsEnumerable();
            }
            else
            {
                resetSet = expression != null ? _dbSet.Where(expression).AsQueryable() : _dbSet.AsQueryable();
            }

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            var enumerable = resetSet as IList<T> ?? resetSet.ToList();
            total = enumerable.Count;
            return enumerable.AsEnumerable();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Count(expression);
        }

        public bool CheckContains(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Count(expression) > 0;
        }
    }
}
