using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PostTagMapRepos
{
    public interface IPostTagMapRepository : IBaseRepository<PostTagMap>
    {
        IList<PostTagMap> GetPostTagsByPostId(Guid postId);

        PostTagMap FindByTagIdPostId(Guid tagId, Guid postId);
    }
}