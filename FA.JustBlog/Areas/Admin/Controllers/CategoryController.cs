using FA.JustBlog.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Category;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _cateService;

        public CategoryController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        [Route("categories")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> ListCategory()
        {
            return await Task.FromResult(View());
        }

        [Route("getcategories")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<JsonResult> GetAllPost()
        {
            var cates = await _cateService.GetAllCategory();
            var cateJson = cates.Select(x =>
                new
                {
                    categoryId = x.Id,
                    categoryName = x.CategoryName,
                    urlSlug = x.UrlSlug,
                    description = x.Description
                }).ToList();
            var json = new { data = cateJson };
            return Json(json);
        }

        [Route("category/create")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> CreateCategory()
        {
            return await Task.FromResult(View());
        }

        [HttpPost("category/create")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> CreateCategory(CategoryDetailsModel cate)
        {
            var result = await _cateService.CreateCategory(cate);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("category/update/{categoryId}")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId)
        {
            var cate = await _cateService.GetCategory(categoryId);

            return View(cate);
        }

        [Route("category/update")]
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryDetailsModel model)
        {
            var result = await _cateService.UpdateCategory(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("category/delete")]
        [HttpPost]
        [Authorize(Roles = "Blog Owner")]
        public async Task<IActionResult> DeleteCategory(Guid cateId)
        {
            var result = await _cateService.DeleteCategory(cateId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}