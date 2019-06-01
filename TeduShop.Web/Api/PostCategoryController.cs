using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service.Services;
using TeduShop.Web.Infrastructure.Core;

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

        public HttpResponseMessage Post(PostCategory postCategory)
        {
            PostCategory result = _postCategoryService.Add(postCategory);
            _postCategoryService.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        public HttpResponseMessage Put(PostCategory postCategory)
        {
            _postCategoryService.Update(postCategory);
            _postCategoryService.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, postCategory);
        }

        public HttpResponseMessage Delete(PostCategory postCategory)
        {
            _postCategoryService.Add(postCategory);
            _postCategoryService.Commit();
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("getall")]
        public HttpResponseMessage Get()
        {
            System.Collections.Generic.IEnumerable<PostCategory> result = _postCategoryService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
