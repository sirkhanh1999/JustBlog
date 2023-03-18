namespace Entity.Entity
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public bool Published { get; set; }
        public string UrlSlug { get; set; }
        public DateTime PostedOn { get; set; }
        public bool Modified { get; set; }
        public int ViewCount { get; set; }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
        public IList<PostTagMap> PostTagMaps { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}