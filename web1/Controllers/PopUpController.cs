using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Models;
using Piranha.AspNetCore.Services;
using Piranha.Extend;
using Piranha.Extend.Blocks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using web1.Models;

namespace web1.Controllers
{
    public class PopUpController : Controller
    {
        private readonly IApi _api;
        private readonly IModelLoader _loader;
        private StandardPost _fallbackPost;

        public PopUpController(IApi api, IModelLoader loader)
        {
            _api = api;
            _loader = loader;
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
                    if (model == null)
                        partialModel = GetFallback();
                    else
                        partialModel = GetPartial(model);
                }
                else
                {
                    partialModel = GetFallback();
                }
            }
            catch
            {
                partialModel = GetFallback();
            }

            return PartialView(partialModel);
        }

        private SinglePost<StandardPost> GetPartial(StandardPost post)
        {
            return new(_api, _loader) { Data = post };
        }

        private SinglePost<StandardPost> GetFallback()
        {
            if (_fallbackPost is null)
            {
                var contents = new HtmlBlock
                {
                    Body = "Произошла ошибка! Мы не смогли найти запрошенные данные."
                };
                var post = new StandardPost
                {
                    Title = "Произошла ошибка!",
                    Blocks = new List<Block>() { contents }
                };

                _fallbackPost = post;
            }

            return GetPartial(_fallbackPost);
        }
    }
}