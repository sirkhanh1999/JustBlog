using Model.Tag;

namespace FA.JustBlog.Services.TagService
{
    public interface ITagService
    {
        Task<IList<PopularTagModel>> GetPopularTags(int size);

        Task<IList<TagDetailsModel>> GetAllTag();

        Task<bool> UpdateTag(TagDetailsModel model);

        Task<TagDetailsModel> GetTag(Guid tagId);

        Task<bool> DeleteTag(Guid tagId);

        Task<bool> CreateTag(TagDetailsModel model);
    }
}