using Entity.Context;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PostTagMapRepos
{
    public class PostTagMapRepository : BaseRepository<PostTagMap>, IPostTagMapRepository
    {
        public PostTagMapRepository(JustBlogContext context) : base(context)
        {
        }

        public PostTagMap FindByTagIdPostId(Guid tagId, Guid postId)
        {
            return context.PostTagMaps.FirstOrDefault(x => x.TagId == tagId && x.PostId == postId);
        }

        public IList<PostTagMap> GetPostTagsByPostId(Guid postId)
        {
            return context.PostTagMaps.Where(x => x.PostId == postId).Select(x => x).ToList();
        }
    }
}