using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service.Infrastructure;

namespace TeduShop.Service.Services
{
    public interface IPostCategoryService : IEntityService<PostCategory>
    {
        IEnumerable<PostCategory> GetByParent(int parentId);
    }
    public class PostCategoryService : EntityService<PostCategory>, IPostCategoryService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IPostCategoryRepository _repository;
        public PostCategoryService(IUnitOfWork unitOfWork, IPostCategoryRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IEnumerable<PostCategory> GetByParent(int parentId)
        {
            return _repository.GetMulti(x => x.Status && x.ParentId == parentId);
        }
    }
}
