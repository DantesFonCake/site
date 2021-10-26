using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Models;
using Piranha.AspNetCore.Services;
using System;
using System.Threading.Tasks;
using web1.Models;

namespace web1.Controllers
{
    public class PopUpController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;

        public PopUpController(IApi api, IModelLoader loader)
        {
            _api = api;
            _loader = loader;
        }

        [Route("/serialized/{postid?}")]
        public async Task<IActionResult> PopUpPost(Guid id, string postid = null)
        {
            if (!string.IsNullOrEmpty(postid))
            {
                StandardPost model = await _api.Posts.GetByIdAsync<StandardPost>(Guid.Parse(postid));
                SinglePost<StandardPost> partialModel = new(_api, _loader) { Data = model };
                return base.PartialView(partialModel);
            }
            else
            {
                return Json("Error occured");
            }
        }
    }
}
