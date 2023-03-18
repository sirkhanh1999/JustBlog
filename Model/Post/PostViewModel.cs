using Model.Tag;

namespace Model.Post
{
    public class PostViewModel
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime PostedOn { get; set; }
        public int ViewCount { get; set; }
        public decimal Rate { get; set; }
        public string Category { get; set; }
        public IList<TagViewModel> TagsName { get; set; }
        public string UrlSlug { get; set; }
        public bool Published { get; set; }
    }
}