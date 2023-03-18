using Common;
using Entity.Entity;
using Model.Post;
using Model.Tag;
using Repository;

namespace FA.JustBlog.Services.PostService
{
    public class PostService : Service<PostService>, IPostService
    {
        public PostService(IUnitOfWork unit, ILogger<PostService> logger) : base(unit, logger)
        {
        }

        public async Task<IList<PostViewModel>> GetAllPostView()
        {
            var result = new List<PostViewModel>();
            try
            {
                var posts = _unit.PostRepository.GetAll();

                if (posts != null)
                {
                    foreach (var item in posts)
                    {
                        var post = new PostViewModel();
                        var cate = _unit.CategoryRepository.Find(item.CategoryId);
                        var tags = _unit.TagRepository.GetTagsByPostId(item.Id);
                        post.PostId = item.Id;
                        post.Title = item.Title;
                        post.UrlSlug = item.UrlSlug;
                        post.ShortDescription = item.ShortDescription;
                        post.PostedOn = item.PostedOn;
                        post.ViewCount = item.ViewCount;
                        post.Published = item.Published;
                        post.Rate = decimal.Round(Convert.ToDecimal(item.TotalRate) / (item.RateCount == 0 ? 1 : item.RateCount), 1);

                        if (cate != null)
                        {
                            post.Category = cate.Name;
                        }
                        if (tags != null)
                        {
                            post.TagsName = tags.OrderBy(x => x.Name).Select(x => new TagViewModel() { TagName = x.Name }).ToList();
                        }

                        result.Add(post);
                    }
                }
                result = result.OrderByDescending(x => x.PostedOn).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<IList<PostTitleModel>> GetMostViewedPosts(int size)
        {
            var result = new List<PostTitleModel>();
            try
            {
                var posts = _unit.PostRepository.GetMostViewedPost(size);
                foreach (var post in posts)
                {
                    var postTitle = new PostTitleModel();
                    postTitle.Title = post.Title;
                    postTitle.PostId = post.Id;
                    postTitle.UrlSlug = post.UrlSlug;
                    postTitle.PostedOn = post.PostedOn;
                    result.Add(postTitle);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<IList<PostTitleModel>> GetLatestPosts(int size)
        {
            var result = new List<PostTitleModel>();
            try
            {
                var posts = _unit.PostRepository.GetLatestPost(size);
                foreach (var post in posts)
                {
                    var postTitle = new PostTitleModel();
                    postTitle.Title = post.Title;
                    postTitle.PostId = post.Id;
                    postTitle.UrlSlug = post.UrlSlug;
                    postTitle.PostedOn = post.PostedOn;
                    result.Add(postTitle);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<IList<PostViewModel>> GetAllPostByCategory(string category)
        {
            var result = new List<PostViewModel>();
            try
            {
                var posts = _unit.PostRepository.GetPostsByCategory(category);
                if (posts != null)
                {
                    foreach (var item in posts)
                    {
                        var post = new PostViewModel();
                        var cate = _unit.CategoryRepository.Find(item.CategoryId);
                        var tags = _unit.TagRepository.GetTagsByPostId(item.Id);
                        post.PostId = item.Id;
                        post.Title = item.Title;
                        post.UrlSlug = item.UrlSlug;
                        post.ShortDescription = item.ShortDescription;
                        post.PostedOn = item.PostedOn;
                        post.ViewCount = item.ViewCount;
                        post.Rate = decimal.Round(Convert.ToDecimal(item.TotalRate) / (item.RateCount == 0 ? 1 : item.RateCount), 1);
                        if (cate != null)
                        {
                            post.Category = cate.Name;
                        }
                        if (tags != null)
                        {
                            post.TagsName = tags.Select(x => new TagViewModel() { TagName = x.Name }).ToList();
                        }
                        result.Add(post);
                    }
                }
                result = result.OrderByDescending(x => x.PostedOn).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<IList<PostViewModel>> GetAllPostByTag(string tag)
        {
            var result = new List<PostViewModel>();
            try
            {
                var posts = _unit.PostRepository.GetPostsByTag(tag);
                if (posts != null)
                {
                    foreach (var item in posts)
                    {
                        var post = new PostViewModel();
                        var cate = _unit.CategoryRepository.Find(item.CategoryId);
                        var tags = _unit.TagRepository.GetTagsByPostId(item.Id);
                        post.PostId = item.Id;
                        post.Title = item.Title;
                        post.UrlSlug = item.UrlSlug;
                        post.ShortDescription = item.ShortDescription;
                        post.PostedOn = item.PostedOn;
                        post.ViewCount = item.ViewCount;
                        post.Rate = decimal.Round(Convert.ToDecimal(item.TotalRate) / item.RateCount, 1);
                        if (cate != null)
                        {
                            post.Category = cate.Name;
                        }
                        if (tags != null)
                        {
                            post.TagsName = tags.Select(x => new TagViewModel() { TagName = x.Name }).ToList();
                        }
                        result.Add(post);
                    }
                }
                result = result.OrderByDescending(x => x.PostedOn).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<PostDetailsModel> GetPost(Guid postId)
        {
            var result = new PostDetailsModel();
            try
            {
                var post = _unit.PostRepository.Find(postId);
                if (post != null)
                {
                    var cate = _unit.CategoryRepository.Find(post.CategoryId);
                    var tags = _unit.TagRepository.GetTagsByPostId(post.Id);
                    result.Id = post.Id;
                    result.Title = post.Title;
                    result.UrlSlug = post.UrlSlug;
                    result.ShortDescription = post.ShortDescription;
                    result.PostContent = post.PostContent;
                    result.PostedOn = post.PostedOn;
                    result.ViewCount = post.ViewCount;
                    result.Rate = decimal.Round(Convert.ToDecimal(post.TotalRate) / post.RateCount, 1);
                    if (cate != null)
                    {
                        result.Category = cate.Name;
                    }
                    if (tags != null)
                    {
                        result.TagsName = string.Join(",", tags.Select(x => x.Name).ToList());
                    }

                    result.CategoryId = post.CategoryId;
                    result.Published = post.Published;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<PostDetailsModel> FindPost(int year, int month, string urlSlug)
        {
            var result = new PostDetailsModel();
            try
            {
                var post = _unit.PostRepository.FindPost(year, month, urlSlug);
                if (post != null)
                {
                    var cate = _unit.CategoryRepository.Find(post.CategoryId);
                    var tags = _unit.TagRepository.GetTagsByPostId(post.Id);
                    result.Id = post.Id;
                    result.Title = post.Title;
                    result.UrlSlug = post.UrlSlug;
                    result.ShortDescription = post.ShortDescription;
                    result.PostContent = post.PostContent;
                    result.PostedOn = post.PostedOn;
                    result.ViewCount = post.ViewCount;
                    result.Rate = decimal.Round(Convert.ToDecimal(post.TotalRate) / (post.RateCount == 0 ? 1 : post.RateCount), 1);
                    if (cate != null)
                    {
                        result.Category = cate.Name;
                    }
                    if (tags != null)
                    {
                        result.TagsName = string.Join(",", tags.OrderBy(x => x.Name).Select(x => x.Name).ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<bool> CreatePost(PostCreateModel model)
        {
            try
            {
                if (model.Title == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.ShortDescription == null)
                {
                    return await Task.FromResult(false);
                }

                var post = new Post();

                post.Id = Guid.NewGuid();
                post.Title = model.Title;
                post.ShortDescription = model.ShortDescription;
                post.PostContent = model.PostContent ?? "";
                post.Published = model.Published;
                post.CategoryId = model.CategoryId;
                post.PostedOn = DateTime.Now;
                post.UrlSlug = SeoUrlHepler.FrientlyUrl(model.Title);
                post.Modified = false;

                _unit.PostRepository.Add(post);

                if (model.TagsName != null)
                {
                    var tagsString = model.TagsName.Split(",");
                    foreach (var tag in tagsString)
                    {
                        if (_unit.TagRepository.GetTagByUrlSlug(SeoUrlHepler.FrientlyUrl(tag)) == null)
                        {
                            var newtag = new Tag();
                            newtag.Id = new Guid();
                            newtag.Name = tag;
                            newtag.UrlSlug = SeoUrlHepler.FrientlyUrl(tag);
                            newtag.Decription = tag;

                            _unit.TagRepository.Add(newtag);
                            _unit.PostTagMapRepository.Add(new PostTagMap() { PostId = post.Id, TagId = newtag.Id });
                        }
                        else
                        {
                            var oldtag = _unit.TagRepository.GetTagByUrlSlug(SeoUrlHepler.FrientlyUrl(tag));
                            _unit.PostTagMapRepository.Add(new PostTagMap() { PostId = post.Id, TagId = oldtag.Id });
                        }
                    }
                }

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

        public async Task<bool> DeletePost(Guid postId)
        {
            try
            {
                _unit.PostRepository.Delete(postId);

                var posttags = _unit.PostTagMapRepository.GetPostTagsByPostId(postId);

                _unit.PostTagMapRepository.RemoveRange(posttags);

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

        public async Task<bool> UpdatePost(PostDetailsModel model)
        {
            try
            {
                if (model.Title == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.ShortDescription == null)
                {
                    return await Task.FromResult(false);
                }

                var post = _unit.PostRepository.Find(model.Id);
                var tags = _unit.TagRepository.GetTagsByPostId(model.Id);

                var oldTags = tags.Select(x => x.Name).ToList();
                List<string>? newTags = new List<string>();

                if (model.TagsName == null)
                {
                }
                else
                {
                    newTags = model.TagsName.Split(",").ToList();
                }

                string[] canXoa = oldTags.Where(x => !newTags.Contains(x)).ToArray();
                string[] canThem = newTags.Where(x => !oldTags.Contains(x)).ToArray();

                if (canXoa.Length > 0)
                {
                    var listTagIdCanXoa = new List<Guid>();
                    foreach (var item in canXoa)
                    {
                        var tagCanXoa = _unit.TagRepository.GetTagByName(item);
                        listTagIdCanXoa.Add(tagCanXoa.Id);
                    }
                    foreach (var item in listTagIdCanXoa)
                    {
                        var postTag = _unit.PostTagMapRepository.FindByTagIdPostId(item, model.Id);
                        _unit.PostTagMapRepository.Delete(postTag);
                    }
                }

                if (canThem.Length > 0)
                {
                    var listTagIdCanThem = new List<Guid>();
                    foreach (var item in canThem)
                    {
                        var tagCanThem = _unit.TagRepository.GetTagByName(item);
                        if (tagCanThem == null)
                        {
                            var newtag = new Tag();
                            newtag.Id = new Guid();
                            newtag.Name = item;
                            newtag.UrlSlug = SeoUrlHepler.FrientlyUrl(item);
                            newtag.Decription = item;

                            _unit.TagRepository.Add(newtag);
                            _unit.PostTagMapRepository.Add(new PostTagMap() { PostId = model.Id, TagId = newtag.Id });
                        }
                        else
                        {
                            listTagIdCanThem.Add(tagCanThem.Id);
                        }
                    }
                    foreach (var item in listTagIdCanThem)
                    {
                        _unit.PostTagMapRepository.Add(new PostTagMap() { PostId = model.Id, TagId = item });
                    }
                }

                // Update
                post.Title = model.Title;
                post.ShortDescription = model.ShortDescription;
                post.PostContent = model.PostContent ?? "";
                post.Published = model.Published;
                post.CategoryId = model.CategoryId;
                post.PostedOn = model.PostedOn;
                post.UrlSlug = SeoUrlHepler.FrientlyUrl(model.Title);
                post.Modified = true;

                _unit.PostRepository.Update(post);

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