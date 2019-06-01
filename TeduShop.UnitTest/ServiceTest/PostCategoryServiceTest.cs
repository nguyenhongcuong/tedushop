using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service.Services;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _postCategories;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockUnitOfWork.Object, _mockRepository.Object);
            _postCategories = new List<PostCategory>
            {
                new PostCategory{Id = 1, Name = "Danh mục 1", Alias = "danh-muc-1", Status = true}
            };
        }

        [TestMethod]
        public void PostCateogry_Service_GetAll()
        {
            // setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_postCategories);

            // call action
            IEnumerable<PostCategory> result = _categoryService.Get();

            // compare
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void PostCateogry_Service_Create()
        {
            PostCategory postCategory = new PostCategory
            {
                Name = "Test Category",
                Alias = "test-category",
                Status = true
            };

            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) =>
            {
                p.Id = 1;
                return p;
            });

            PostCategory result = _categoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}
