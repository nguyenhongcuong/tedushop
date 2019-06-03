using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service.Services;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Infrastructure.Extensions;
using TeduShop.Web.Models;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiBaseController
    {
        private readonly IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            _postCategoryService = postCategoryService;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryViewModel);
                    PostCategory result = _postCategoryService.Add(postCategory);
                    _postCategoryService.Commit();
                    response = request.CreateResponse(HttpStatusCode.Created, result);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (ModelState.IsValid)
                {
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryViewModel);
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Commit();
                    response = request.CreateResponse(HttpStatusCode.OK, postCategory);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (ModelState.IsValid)
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Commit();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response;
                if (ModelState.IsValid)
                {
                    IEnumerable<PostCategory> result = _postCategoryService.Get();
                    IEnumerable<PostCategoryViewModel> resultViewModel = Mapper.Map<IEnumerable<PostCategoryViewModel>>(result);
                    response = request.CreateResponse(HttpStatusCode.OK, resultViewModel.ToList());
                }
                else
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

    }
}
