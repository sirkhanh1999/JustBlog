using Common;
using FA.JustBlog.Services.PostService;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Text.RegularExpressions;
using X.PagedList;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET
        [Route("Category/{category}")]
        [HttpGet]
        public async Task<IActionResult> GetPostByCategory(string category, int? page)
        {
            category = category.Replace("-", " ");
            var posts = await _postService.GetAllPostByCategory(category);
            posts.OrderByDescending(x => x.PostedOn);
            ViewData["Category"] = category;

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var result = posts.ToPagedList(pageNumber, pageSize);
            return View(result);
        }

        // GET
        [Route("Tag/{tag}")]
        [HttpGet]
        public async Task<IActionResult> GetPostByTag(string tag, int? page)
        {
            var posts = await _postService.GetAllPostByTag(tag);
            posts.OrderByDescending(x => x.PostedOn);
            ViewData["Tag"] = tag;

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var result = posts.ToPagedList(pageNumber, pageSize);
            return View(result);
        }

        // GET
        [Route("Post/{year}/{month}/{urlSlug}", Name = "Route_Details")]
        [HttpGet]
        public async Task<IActionResult> DetailsByUrl(int year, string month, string urlSlug)
        {
            bool isValid = int.TryParse(month, out int monthInt);
            if (isValid)
            {
                var post = await _postService.FindPost(year, monthInt, urlSlug);
                //if (post == null)
                //{
                //    return RedirectToAction("PageNotFound", "Error");
                //}
                return View("~/Views/Post/Details.cshtml", post);
            }
            else
            {
                return BadRequest();
            }
           
        }
    }
}