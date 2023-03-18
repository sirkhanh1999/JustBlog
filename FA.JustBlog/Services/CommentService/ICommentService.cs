using Model.Comment;

namespace FA.JustBlog.Services.CommentService
{
    public interface ICommentService
    {
        Task<IList<CommentDetailsModel>> GetAllComment();

        Task<IList<CommentDetailsModel>> GetCommentForPost(Guid postId);

        Task<CommentDetailsModel> GetComment(Guid commentId);

        Task<bool> DeleteComment(Guid tagId);

        Task<bool> CreateComment(CommentDetailsModel model);

        Task<bool> UpdateComment(CommentDetailsModel model);
    }
}