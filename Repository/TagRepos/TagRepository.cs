using Entity.Context;
using Entity.Entity;

namespace Repository.TagRepos
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context)
        {
        }

        public IList<Tag> GetPopularTags(int size)
        {
            var tags = (from post in context.Posts
                        join posttag in context.PostTagMaps on post.Id equals posttag.PostId
                        join tagg in context.Tags on posttag.TagId equals tagg.Id
                        orderby (post.TotalRate / post.RateCount) descending
                        group post by tagg.Id into g
                        orderby g.Count() descending
                        select g).Select(g => g.Key).ToList();

            var listTag = new List<Tag>();
            foreach (var item in tags)
            {
                var tag = context.Tags.Where(x => x.Id == item).Select(x => x).FirstOrDefault();
                if (tag != null)
                {
                    listTag.Add(tag);
                }
            }

            var result = listTag.Take(size).ToList();
            return result;
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return context.Tags.FirstOrDefault(x => x.UrlSlug == urlSlug);
        }

        public Tag GetTagByName(string name)
        {
            return context.Tags.FirstOrDefault(x => x.Name == name);
        }

        public IList<Tag> GetTagsByPostId(Guid postId)
        {
            var result = from post in context.Posts
                         join posttag in context.PostTagMaps on post.Id equals posttag.PostId
                         join tagg in context.Tags on posttag.TagId equals tagg.Id
                         where post.Id == postId
                         select tagg;

            return result.ToList();
        }
    }
}