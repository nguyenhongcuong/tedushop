using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service.Infrastructure;

namespace TeduShop.Service.Services
{
    public interface IProductService : IEntityService<Product>
    {

    }
    public class ProductService : EntityService<Product>, IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IProductRepository _repository;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
    }
}
