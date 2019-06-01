using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using TeduShop.Model.Models;
using TeduShop.Service.Services;

namespace TeduShop.Web.Infrastructure.Core
{
    public class ApiBaseController : ApiController
    {
        private readonly IErrorService _errorService;

        public ApiBaseController(IErrorService errorService)
        {
            _errorService = errorService;
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error error = new Error
                {
                    CreatedDate = DateTime.Now,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };

                _errorService.Add(error);
                _errorService.Commit();
            }
            catch
            {
                // ignored
            }
        }
    }
}
