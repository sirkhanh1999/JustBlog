using Model.Post;

namespace FA.JustBlog.Services.PostService
{
    public interface IPostService
    {
        Task<IList<PostViewModel>> GetAllPostView();

        Task<IList<PostTitleModel>> GetMostViewedPosts(int size);

        Task<IList<PostTitleModel>> GetLatestPosts(int size);

        Task<IList<PostViewModel>> GetAllPostByCategory(string category);

        Task<IList<PostViewModel>> GetAllPostByTag(string tag);

        Task<PostDetailsModel> GetPost(Guid postId);

        Task<PostDetailsModel> FindPost(int year, int month, string urlSlug);

        Task<bool> CreatePost(PostCreateModel model);

        Task<bool> DeletePost(Guid postId);

        Task<bool> UpdatePost(PostDetailsModel model);
    }
}