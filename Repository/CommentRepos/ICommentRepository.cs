using Entity.Entity;

namespace Repository.CommentRepos
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        void AddComment(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody);

        IList<Comment> GetCommentsForPost(Guid postId);

        IList<Comment> GetCommentsForPost(Post post);
    }
}