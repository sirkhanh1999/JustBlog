using FA.JustBlog.Services.PostService;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FA.JustBlog.ViewComponents
{
    public class LatestPosts : ViewComponent
    {
        private readonly IPostService _postService;

        public LatestPosts(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _postService.GetLatestPosts(5);
            return await Task.FromResult(View(posts));
        }
    }
}