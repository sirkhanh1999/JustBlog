using FA.JustBlog.Services.PostService;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace FA.JustBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        // GET
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Index(int? page, string search)
        {
            var posts = await _postService.GetAllPostView();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (!String.IsNullOrEmpty(search))
            {
                posts = posts.Where(x => x.Title.ToLower().Contains(search.Trim().ToLower())
                                    || x.ShortDescription.ToLower().Contains(search.Trim().ToLower()))
                             .ToList();
                pageSize = posts.Count;
            }
            
            var result = posts.ToPagedList(pageNumber, pageSize);
            return View(result);
        }
    }
}