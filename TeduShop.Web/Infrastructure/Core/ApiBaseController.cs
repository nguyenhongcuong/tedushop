using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage response = null;
            try
            {
                response = func.Invoke();

            }
            catch (DbEntityValidationException dbEnEx)
            {
                LogError(dbEnEx);
                if (dbEnEx.InnerException != null)
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, dbEnEx.InnerException.Message);
            }
            catch (DbUpdateException dxEx)
            {
                LogError(dxEx);
                if (dxEx.InnerException != null)
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, dxEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
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
