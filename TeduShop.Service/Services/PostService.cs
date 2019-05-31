using System.Collections.Generic;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service.Infrastructure;

namespace TeduShop.Service.Services
{
    public interface IPostService : IEntityService<Post>
    {
        IEnumerable<Post> Get(string tag, int index, int size, out int totalRow);
    }
    public class PostService : EntityService<Post>, IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _repository;
        public PostService(IUnitOfWork unitOfWork, IPostRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IEnumerable<Post> Get(string tag, int index, int size, out int totalRow)
        {
            return _repository.GetMultiPaging(x => x.Status, out totalRow, index, size);
        }

        public override IEnumerable<Post> Get(string[] includes)
        {
            return base.Get(new[] { "PostCategory" });
        }

    }
}
