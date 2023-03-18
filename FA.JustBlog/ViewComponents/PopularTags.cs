using FA.JustBlog.Services.TagService;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FA.JustBlog.ViewComponents
{
    public class PopularTags : ViewComponent
    {
        private readonly ITagService _tagService;

        public PopularTags(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _tagService.GetPopularTags(10);
            return await Task.FromResult(View(posts));
        }
    }
}