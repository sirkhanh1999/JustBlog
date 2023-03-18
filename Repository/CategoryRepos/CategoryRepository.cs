using Entity.Context;
using Entity.Entity;

namespace Repository.CategoryRepos
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext context) : base(context)
        {
        }
    }
}