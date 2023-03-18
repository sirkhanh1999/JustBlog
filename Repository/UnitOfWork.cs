using Entity.Context;
using Repository.CategoryRepos;
using Repository.CommentRepos;
using Repository.PostRepos;
using Repository.PostTagMapRepos;
using Repository.TagRepos;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private ICommentRepository _commentRepository;
        private IPostTagMapRepository _postTagMapRepository;

        public UnitOfWork(JustBlogContext context)
        {
            _context = context;
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_context));
        public IPostRepository PostRepository => _postRepository ?? (_postRepository = new PostRepository(_context));
        public ITagRepository TagRepository => _tagRepository ?? (_tagRepository = new TagRepository(_context));
        public ICommentRepository CommentRepository => _commentRepository ?? (_commentRepository = new CommentRepository(_context));
        public IPostTagMapRepository PostTagMapRepository => _postTagMapRepository ?? (_postTagMapRepository = new PostTagMapRepository(_context));

        public void Dispose()
        {
            _context.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}