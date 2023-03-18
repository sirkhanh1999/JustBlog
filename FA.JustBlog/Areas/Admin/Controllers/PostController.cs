using FA.JustBlog.Services.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Post;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("post/create")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> CreatePost()
        {
            return await Task.FromResult(View());
        }

        [HttpPost("post/create")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> CreatePost(PostCreateModel post)
        {
            var result = await _postService.CreatePost(post);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("posts")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> ListPost()
        {
            return await Task.FromResult(View());
        }

        [Route("post/allpost")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetAllPost()
        {
            var posts = await _postService.GetAllPostView();
            var postJson = posts.Select(x =>
                new
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    PostedOn = x.PostedOn.ToString("dd/MM/yyyy hh:mm tt"),
                    ViewCount = x.ViewCount,
                    Rate = x.Rate,
                    Category = x.Category,
                    TagsName = x.TagsName,
                    UrlSlug = x.UrlSlug,
                    Published = x.Published
                }).ToList();
            var json = new { data = postJson };
            return Json(json);
        }

        [Route("post/delete")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var result = await _postService.DeletePost(postId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("post/update/{postId}")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> UpdatePost(Guid postId)
        {
            var post = await _postService.GetPost(postId);

            return View(post);
        }

        [Route("post/update")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostDetailsModel model)
        {
            var result = await _postService.UpdatePost(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("post/lastestposts")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetLastestPosts()
        {
            var posts = await _postService.GetAllPostView();
            var postJson = posts.OrderByDescending(x => x.PostedOn).Select(x =>
                new
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    PostedOn = x.PostedOn.ToString("dd/MM/yyyy hh:mm tt"),
                    ViewCount = x.ViewCount,
                    Rate = x.Rate,
                    Category = x.Category,
                    TagsName = x.TagsName,
                    UrlSlug = x.UrlSlug,
                    Published = x.Published
                }).ToList();
            var json = new { data = postJson };
            return Json(json);
        }

        [Route("post/mostviewposts")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetMostViewPosts()
        {
            var posts = await _postService.GetAllPostView();
            var postJson = posts.OrderByDescending(x => x.ViewCount).Select(x =>
                new
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    PostedOn = x.PostedOn.ToString("dd/MM/yyyy hh:mm tt"),
                    ViewCount = x.ViewCount,
                    Rate = x.Rate,
                    Category = x.Category,
                    TagsName = x.TagsName,
                    UrlSlug = x.UrlSlug,
                    Published = x.Published
                }).ToList();
            var json = new { data = postJson };
            return Json(json);
        }

        [Route("post/mostinterposts")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetMostInterestingPosts()
        {
            var posts = await _postService.GetAllPostView();
            var postJson = posts.OrderByDescending(x => x.Rate).Select(x =>
                new
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    PostedOn = x.PostedOn.ToString("dd/MM/yyyy hh:mm tt"),
                    ViewCount = x.ViewCount,
                    Rate = x.Rate,
                    Category = x.Category,
                    TagsName = x.TagsName,
                    UrlSlug = x.UrlSlug,
                    Published = x.Published
                }).ToList();
            var json = new { data = postJson };
            return Json(json);
        }

        [Route("post/publishedposts")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<JsonResult> GetPublishedPosts()
        {
            var posts = await _postService.GetAllPostView();
            var postJson = posts.Where(x => x.Published == true).Select(x =>
                new
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    PostedOn = x.PostedOn.ToString("dd/MM/yyyy hh:mm tt"),
                    ViewCount = x.ViewCount,
                    Rate = x.Rate,
                    Category = x.Category,
                    TagsName = x.TagsName,
                    UrlSlug = x.UrlSlug,
                    Published = x.Published
                }).ToList();
            var json = new { data = postJson };
            return Json(json);
        }

        [Route("post/unpublishedposts")]
        [Authorize(Roles = "Blog Owner")]
        public async Task<JsonResult> GetUnPublishedPosts()
        {
            var posts = await _postService.GetAllPostView();
            var postJson = posts.Where(x => x.Published == false).Select(x =>
                new
                {
                    PostId = x.PostId,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    PostedOn = x.PostedOn.ToString("dd/MM/yyyy hh:mm tt"),
                    ViewCount = x.ViewCount,
                    Rate = x.Rate,
                    Category = x.Category,
                    TagsName = x.TagsName,
                    UrlSlug = x.UrlSlug,
                    Published = x.Published
                }).ToList();
            var json = new { data = postJson };
            return Json(json);
        }
    }
}