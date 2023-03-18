using Entity.Context;
using Entity.Entity;

namespace Repository.CommentRepos
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext context) : base(context)
        {
        }

        public void AddComment(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment()
            {
                Name = commentName,
                Email = commentEmail,
                PostId = postId,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };

            dbSet.Add(comment);
        }

        public IList<Comment> GetCommentsForPost(Guid postId)
        {
            return context.Comments.Where(x => x.PostId == postId).Select(x => x).ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return context.Comments.Where(x => x.PostId == post.Id).Select(x => x).ToList();
        }
    }
}