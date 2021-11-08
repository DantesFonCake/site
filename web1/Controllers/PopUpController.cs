using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Models;
using Piranha.AspNetCore.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using web1.Models;

namespace web1.Controllers
{
    public class PopUpController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;
        private readonly IDb _db;
        private StandardPost _fallbackPost;

        public PopUpController(IApi api, IModelLoader loader, IDb db)
        {
            _api = api;
            _loader = loader;
            _db = db;
        }

        [Route("/serialized/{postid?}")]
        public async Task<IActionResult> PopUpPost(Guid id, string postid = null)
        {
            SinglePost<StandardPost> partialModel;
            try
            {
                if (!string.IsNullOrEmpty(postid) || postid != Guid.Empty.ToString())
                {
                    var model = await _api.Posts.GetByIdAsync<StandardPost>(Guid.Parse(postid));
                    partialModel = GetPartial(model);
                }
                else
                {
                    partialModel = await GetFallback();
                }
            }
            catch
            {
                partialModel =await GetFallback();
            }

            return PartialView(partialModel);
        }

        private SinglePost<StandardPost> GetPartial(StandardPost post)
        {
            return new(_api, _loader) { Data = post };
        }

        private async Task<SinglePost<StandardPost>> GetFallback()
        {
            if (_fallbackPost is null)
            {
                var fallbackId = _db.Posts.Where(x => x.Category.Title == "error").First(x => x.Tags.Select(x => x.Tag.Title).Contains("postnotfoundfallback")).Id;
                _fallbackPost = await _api.Posts.GetByIdAsync<StandardPost>(fallbackId);
            }

            SinglePost<StandardPost> partialFallback = new(_api, _loader) { Data = _fallbackPost };
            return partialFallback;
        }
    }
}
