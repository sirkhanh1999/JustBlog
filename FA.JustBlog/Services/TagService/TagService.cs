using Common;
using Entity.Entity;
using Model.Tag;
using Repository;

namespace FA.JustBlog.Services.TagService
{
    public class TagService : Service<TagService>, ITagService
    {
        public TagService(IUnitOfWork unit, ILogger<TagService> logger) : base(unit, logger)
        {
        }

        public async Task<IList<TagDetailsModel>> GetAllTag()
        {
            var result = new List<TagDetailsModel>();
            try
            {
                var tags = _unit.TagRepository.GetAll();
                if (tags != null)
                {
                    foreach (var item in tags)
                    {
                        var tag = new TagDetailsModel();
                        tag.Id = item.Id;
                        tag.TagName = item.Name;
                        tag.UrlSlug = item.UrlSlug;
                        tag.Decription = item.Decription;
                        tag.Count = item.Count;
                        result.Add(tag);
                    }
                }
                result = result.OrderBy(c => c.TagName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }

            return await Task.FromResult(result);
        }

        public async Task<IList<PopularTagModel>> GetPopularTags(int size)
        {
            var result = new List<PopularTagModel>();
            try
            {
                var tags = _unit.TagRepository.GetPopularTags(size);
                foreach (var item in tags)
                {
                    var tag = new PopularTagModel();
                    tag.TagName = item.Name;
                    tag.UrlSlug = item.UrlSlug;
                    result.Add(tag);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<TagDetailsModel> GetTag(Guid tagId)
        {
            var result = new TagDetailsModel();
            try
            {
                var tag = _unit.TagRepository.Find(tagId);
                if (tag != null)
                {
                    result.Id = tagId;
                    result.TagName = tag.Name;
                    result.UrlSlug = tag.UrlSlug;
                    result.Decription = tag.Decription;
                    result.Count = tag.Count;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
            }
            return await Task.FromResult(result);
        }

        public async Task<bool> UpdateTag(TagDetailsModel model)
        {
            try
            {
                if (model.TagName == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.Decription == null)
                {
                    return await Task.FromResult(false);
                }

                var tag = _unit.TagRepository.Find(model.Id);

                tag.Name = model.TagName;
                tag.Decription = model.Decription;
                tag.UrlSlug = SeoUrlHepler.FrientlyUrl(model.TagName);
                _unit.TagRepository.Update(tag);

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

        public async Task<bool> DeleteTag(Guid tagId)
        {
            try
            {
                if (_unit.TagRepository.Find(tagId) == null)
                {
                    return await Task.FromResult(false);
                }

                _unit.TagRepository.Delete(tagId);

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

        public async Task<bool> CreateTag(TagDetailsModel model)
        {
            try
            {
                if (model.TagName == null)
                {
                    return await Task.FromResult(false);
                }
                if (model.Decription == null)
                {
                    return await Task.FromResult(false);
                }

                var tag = new Tag();

                tag.Id = Guid.NewGuid();
                tag.Name = model.TagName;
                tag.Decription = model.Decription;
                tag.UrlSlug = SeoUrlHepler.FrientlyUrl(model.TagName);
                _unit.TagRepository.Add(tag);

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