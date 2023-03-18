using FA.JustBlog.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace FA.JustBlog.ViewComponents
{
    public class ListCategory : ViewComponent
    {
        private readonly ICategoryService _cateService;

        public ListCategory(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _cateService.GetAllCategoryName();
            return await Task.FromResult(View(posts));
        }
    }
}