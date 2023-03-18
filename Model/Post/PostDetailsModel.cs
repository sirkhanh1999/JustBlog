using Model.Tag;

namespace Model.Post
{
    public class PostDetailsModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime PostedOn { get; set; }
        public int ViewCount { get; set; }
        public decimal Rate { get; set; }
        public string Category { get; set; }
        public string TagsName { get; set; }
        public string PostContent { get; set; }
        public string UrlSlug { get; set; }
        public Guid CategoryId { get; set; }
        public bool Published { get; set; }
    }
}