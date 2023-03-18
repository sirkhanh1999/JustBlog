using Model.Category;

namespace FA.JustBlog.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IList<CategoryViewModel>> GetAllCategoryName();

        Task<IList<CategoryDetailsModel>> GetAllCategory();

        Task<bool> CreateCategory(CategoryDetailsModel model);

        Task<bool> UpdateCategory(CategoryDetailsModel model);

        Task<CategoryDetailsModel> GetCategory(Guid categoryId);

        Task<bool> DeleteCategory(Guid cateId);
    }
}