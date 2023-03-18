using FA.JustBlog.Services.TagService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Tag;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("tags")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> ListTag()
        {
            return await Task.FromResult(View());
        }

        [Route("gettags")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetAllTag()
        {
            var tags = await _tagService.GetAllTag();
            var tagJson = tags.Select(x =>
                new
                {
                    tagId = x.Id,
                    tagName = x.TagName,
                    urlSlug = x.UrlSlug,
                    description = x.Decription,
                    count = x.Count
                }).ToList();
            var json = new { data = tagJson };
            return Json(json);
        }

        [Route("tag/update/{tagId}")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> UpdateTag(Guid tagId)
        {
            var tag = await _tagService.GetTag(tagId);

            return View(tag);
        }

        [Route("tag/update")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost]
        public async Task<IActionResult> UpdateTag(TagDetailsModel model)
        {
            var result = await _tagService.UpdateTag(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("tag/delete")]
        [Authorize(Roles = "Blog Owner")]
        [HttpGet]
        public async Task<IActionResult> DeleteTag(Guid tagId)
        {
            var result = await _tagService.DeleteTag(tagId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("tag/create")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> CreateTag()
        {
            return await Task.FromResult(View());
        }

        [HttpPost("tag/create")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> CreateTag(TagDetailsModel tag)
        {
            var result = await _tagService.CreateTag(tag);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}