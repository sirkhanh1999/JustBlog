using FA.JustBlog.Services.PostService;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FA.JustBlog.ViewComponents
{
    public class MostViewedPosts : ViewComponent
    {
        private readonly IPostService _postService;

        public MostViewedPosts(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _postService.GetMostViewedPosts(5);
            return await Task.FromResult(View(posts));
        }
    }
}