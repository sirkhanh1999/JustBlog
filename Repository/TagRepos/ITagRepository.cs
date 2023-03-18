using Entity.Entity;

namespace Repository.TagRepos
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        /// <summary>
        /// Get Tag by UrlSlug
        /// </summary>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Tag GetTagByUrlSlug(string urlSlug);

        IList<Tag> GetPopularTags(int size);

        IList<Tag> GetTagsByPostId(Guid postId);

        Tag GetTagByName(string name);
    }
}