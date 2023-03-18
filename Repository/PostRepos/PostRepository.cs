using Entity.Context;
using Entity.Entity;

namespace Repository.PostRepos
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context)
        {
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return context.Posts.FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug.Contains(urlSlug));
        }

        public IList<Post> GetPublisedPosts()
        {
            return context.Posts.Where(x => x.Published == true).Select(x => x).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return context.Posts.Where(x => x.Published == false).Select(x => x).ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return context.Posts.OrderByDescending(x => x.PostedOn).Take(size).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return context.Posts.Where(x => x.PostedOn.Month == monthYear.Month).Select(x => x).ToList();
        }

        public int CountPostsForCategory(string category)
        {
            var result = from post in context.Posts
                         join cate in context.Categories on post.CategoryId equals cate.Id
                         where cate.Name == category
                         group post.Id by cate.Id into g
                         select g.Count();

            return result.FirstOrDefault();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            var result = from post in context.Posts
                         join cate in context.Categories on post.CategoryId equals cate.Id
                         where cate.Name == category
                         group post by cate.Id into g
                         select g.ToList();
            return result.FirstOrDefault();
        }

        public int CountPostsForTag(string tag)
        {
            var result = from post in context.Posts
                         join posttag in context.PostTagMaps on post.Id equals posttag.PostId
                         join tagg in context.Tags on posttag.TagId equals tagg.Id
                         where tagg.Name == tag
                         group post.Id by tagg.Id into g
                         select g.Count();

            return result.FirstOrDefault();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            var result = from post in context.Posts
                         join posttag in context.PostTagMaps on post.Id equals posttag.PostId
                         join tagg in context.Tags on posttag.TagId equals tagg.Id
                         where tagg.Name == tag
                         group post by tagg.Id into g
                         select g.ToList();

            return result.FirstOrDefault();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return context.Posts.OrderByDescending(x => x.ViewCount).Take(size).ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return context.Posts.OrderByDescending(x => (double)(x.TotalRate / x.RateCount)).Take(size).ToList();
        }
    }
}