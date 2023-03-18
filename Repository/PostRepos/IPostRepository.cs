using Entity.Entity;

namespace Repository.PostRepos
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        /// <summary>
        /// Find Post by year, month, UrlSlug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Post FindPost(int year, int month, string urlSlug);

        /// <summary>
        /// Get Publised post
        /// </summary>
        /// <returns></returns>

        IList<Post> GetPublisedPosts();

        /// <summary>
        /// Get UnPublised post
        /// </summary>
        /// <returns></returns>

        IList<Post> GetUnpublisedPosts();

        /// <summary>
        /// Get lastest post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>

        IList<Post> GetLatestPost(int size);

        /// <summary>
        /// Get post by month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>

        IList<Post> GetPostsByMonth(DateTime monthYear);

        /// <summary>
        /// Get Count post for category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        int CountPostsForCategory(string category);

        /// <summary>
        /// Get list post by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        IList<Post> GetPostsByCategory(string category);

        /// <summary>
        /// Get count post for tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>

        int CountPostsForTag(string tag);

        /// <summary>
        /// Get post by tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>

        IList<Post> GetPostsByTag(string tag);

        /// <summary>
        /// GetMostViewedPost
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetMostViewedPost(int size);

        /// <summary>
        /// GetHighestPosts
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetHighestPosts(int size);
    }
}