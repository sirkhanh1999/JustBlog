using Entity.Entity;
using Model.Comment;
using Repository;

namespace FA.JustBlog.Services.CommentService
{
    public class CommentService : Service<CommentService>, ICommentService
    {
        public CommentService(IUnitOfWork unit, ILogger<CommentService> logger) : base(unit, logger)
        {
        }

        public async Task<IList<CommentDetailsModel>> GetAllComment()
        {
            var result = new List<CommentDetailsModel>();
            try
            {
                var comments = _unit.CommentRepository.GetAll();
                if (comments != null)
                {
                    foreach (var item in comments)
                    {
                        var comment = new CommentDetailsModel();
                        var post = _unit.PostRepository.Find(item.PostId);
                        comment.Id = item.Id;
                        comment.Name = item.Name;
                        comment.Email = item.Email;
                        comment.CommentHeader = item.CommentHeader;
                        comment.CommentText = item.CommentText;
                        comment.CommentTime = item.CommentTime;
                        comment.PostId = item.PostId;
                        comment.PostTitle = post.Title;
                        result.Add(comment);
                    }
                }
                result = result.OrderByDescending(c => c.CommentTime).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(result);
        }

        public async Task<IList<CommentDetailsModel>> GetCommentForPost(Guid postId)
        {
            var result = new List<CommentDetailsModel>();
            try
            {
                var comments = _unit.CommentRepository.GetCommentsForPost(postId);
                if (comments != null)
                {
                    foreach (var item in comments)
                    {
                        var comment = new CommentDetailsModel();
                        var post = _unit.PostRepository.Find(item.PostId);
                        comment.Id = item.Id;
                        comment.Name = item.Name;
                        comment.Email = item.Email;
                        comment.CommentHeader = item.CommentHeader;
                        comment.CommentText = item.CommentText;
                        comment.CommentTime = item.CommentTime;
                        comment.PostId = item.PostId;
                        comment.PostTitle = post.Title;
                        result.Add(comment);
                    }
                }
                result = result.OrderBy(c => c.CommentTime).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<CommentDetailsModel> GetComment(Guid commentId)
        {
            var result = new CommentDetailsModel();
            try
            {
                var comment = _unit.CommentRepository.Find(commentId);
                if (comment != null)
                {
                    var post = _unit.PostRepository.Find(comment.PostId);
                    result.Id = comment.Id;
                    result.Name = comment.Name;
                    result.Email = comment.Email;
                    result.CommentHeader = comment.CommentHeader;
                    result.CommentText = comment.CommentText;
                    result.CommentTime = comment.CommentTime;
                    result.PostId = comment.PostId;
                    result.PostTitle = post.Title;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<bool> DeleteComment(Guid commentId)
        {
            try
            {
                if (_unit.CommentRepository.Find(commentId) == null)
                {
                    return await Task.FromResult(false);
                }

                _unit.CommentRepository.Delete(commentId);

                var result = _unit.SaveChanges();
                if (result > 0)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> CreateComment(CommentDetailsModel model)
        {
            try
            {
                if (model.Name == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.Email == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.CommentHeader == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.CommentText == null)
                {
                    return await Task.FromResult(false);
                }

                var comment = new Comment();

                comment.Id = Guid.NewGuid();
                comment.Name = model.Name;
                comment.Email = model.Email;
                comment.CommentHeader = model.CommentHeader;
                comment.CommentText = model.CommentText;
                comment.CommentTime = DateTime.Now;
                comment.PostId = model.PostId;

                _unit.CommentRepository.Add(comment);

                var count = _unit.SaveChanges();
                if (count > 0)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> UpdateComment(CommentDetailsModel model)
        {
            try
            {
                if (model.Name == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.Email == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.CommentHeader == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.CommentText == null)
                {
                    return await Task.FromResult(false);
                }

                var comment = _unit.CommentRepository.Find(model.Id);

                if (comment == null)
                {
                    return await Task.FromResult(false);
                }

                comment.Name = model.Name;
                comment.Email = model.Email;
                comment.CommentHeader = model.CommentHeader;
                comment.CommentText = model.CommentText;
                comment.CommentTime = model.CommentTime;
                comment.PostId = model.PostId;

                _unit.CommentRepository.Update(comment);

                var count = _unit.SaveChanges();
                if (count > 0)
                {
                    return await Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(false);
        }
    }
}