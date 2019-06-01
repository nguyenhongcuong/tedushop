using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IUnitOfWork _unitOfWork;
        private IPostCategoryRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _repository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory
            {
                Name = "Test category",
                Alias = "test-category",
                Status = true
            };
            PostCategory result = _repository.Add(postCategory);
            _unitOfWork.Commit();

            Assert.IsTrue(result.Id > 0);

        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            System.Collections.Generic.IEnumerable<PostCategory> result = _repository.GetAll();
            Assert.IsNotNull(result);
        }
    }
}
