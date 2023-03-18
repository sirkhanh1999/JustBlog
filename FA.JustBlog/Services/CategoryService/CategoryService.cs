using Common;
using Entity.Entity;
using Model.Category;
using Repository;

namespace FA.JustBlog.Services.CategoryService
{
    public class CategoryService : Service<CategoryService>, ICategoryService
    {
        public CategoryService(IUnitOfWork unit, ILogger<CategoryService> logger) : base(unit, logger)
        {
        }

        public async Task<IList<CategoryViewModel>> GetAllCategoryName()
        {
            var result = new List<CategoryViewModel>();
            try
            {
                var cates = _unit.CategoryRepository.GetAll();
                if (cates != null)
                {
                    foreach (var item in cates)
                    {
                        var cate = new CategoryViewModel();
                        cate.Id = item.Id;
                        cate.CategoryName = item.Name;
                        cate.UrlSlug = item.UrlSlug;
                        result.Add(cate);
                    }
                }
                result = result.OrderBy(c => c.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<IList<CategoryDetailsModel>> GetAllCategory()
        {
            var result = new List<CategoryDetailsModel>();
            try
            {
                var cates = _unit.CategoryRepository.GetAll();
                if (cates != null)
                {
                    foreach (var item in cates)
                    {
                        var cate = new CategoryDetailsModel();
                        cate.Id = item.Id;
                        cate.CategoryName = item.Name;
                        cate.UrlSlug = item.UrlSlug;
                        cate.Description = item.Description;
                        result.Add(cate);
                    }
                }
                result = result.OrderBy(c => c.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(result);
        }

        public async Task<bool> CreateCategory(CategoryDetailsModel model)
        {
            try
            {
                if (model.CategoryName == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.Description == null)
                {
                    return await Task.FromResult(false);
                }

                var cate = new Category();

                cate.Id = Guid.NewGuid();
                cate.Name = model.CategoryName;
                cate.Description = model.Description;
                cate.UrlSlug = SeoUrlHepler.FrientlyUrl(model.CategoryName);

                _unit.CategoryRepository.Add(cate);

                var count = _unit.SaveChanges();
                if (count > 0)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateCategory(CategoryDetailsModel model)
        {
            try
            {
                if (model.CategoryName == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.Description == null)
                {
                    return await Task.FromResult(false);
                }

                var cate = _unit.CategoryRepository.Find(model.Id);

                cate.Name = model.CategoryName;
                cate.Description = model.Description;
                cate.UrlSlug = SeoUrlHepler.FrientlyUrl(model.CategoryName);

                _unit.CategoryRepository.Update(cate);

                var count = _unit.SaveChanges();
                if (count > 0)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(false);
        }

        public async Task<CategoryDetailsModel> GetCategory(Guid categoryId)
        {
            var result = new CategoryDetailsModel();
            try
            {
                var category = _unit.CategoryRepository.Find(categoryId);
                if (category != null)
                {
                    result.Id = categoryId;
                    result.CategoryName = category.Name;
                    result.Description = category.Description;
                    result.UrlSlug = category.UrlSlug;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(result);
        }

        public async Task<bool> DeleteCategory(Guid cateId)
        {
            try
            {
                if (_unit.CategoryRepository.Find(cateId) == null)
                {
                    return await Task.FromResult(false);
                }

                _unit.CategoryRepository.Delete(cateId);

                var result = _unit.SaveChanges();
                if (result > 0)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(false);
        }
    }
}