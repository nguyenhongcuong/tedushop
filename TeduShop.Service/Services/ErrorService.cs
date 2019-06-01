using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service.Infrastructure;

namespace TeduShop.Service.Services
{
    public interface IErrorService : IEntityService<Error>
    {

    }
    public class ErrorService : EntityService<Error>, IErrorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IErrorRepository _repository;
        public ErrorService(IUnitOfWork unitOfWork, IErrorRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
    }
}
