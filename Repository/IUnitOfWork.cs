using Repository.CategoryRepos;
using Repository.CommentRepos;
using Repository.PostRepos;
using Repository.PostTagMapRepos;
using Repository.TagRepos;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; } // read only
        public IPostRepository PostRepository { get; } // read only
        public ITagRepository TagRepository { get; } // read only
        public ICommentRepository CommentRepository { get; } // read only
        public IPostTagMapRepository PostTagMapRepository { get; } // read only

        /// <summary>
        /// Save change database
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}