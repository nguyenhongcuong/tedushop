using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TeduShop.Data.Infrastructure;

namespace TeduShop.Service.Infrastructure
{
    public abstract class EntityService<T> : IEntityService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;

        protected EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public virtual T Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual T Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public virtual T Delete(int id)
        {
            return _repository.Delete(id);
        }

        public virtual IEnumerable<T> Get(string[] includes)
        {
            return _repository.GetAll(includes);
        }

        public virtual IEnumerable<T> GetPaging(Expression<Func<T, bool>> expression, int index, int size, out int totalRow)
        {
            return _repository.GetMultiPaging(expression, out totalRow, index, size);
        }

        public virtual T Get(int id)
        {
            return _repository.GetSingleById(id);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
