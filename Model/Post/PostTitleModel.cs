namespace Model.Post
{
    public class PostTitleModel
    {
        public Guid PostId { get; set; }
        public string Title { get; set; }
        public DateTime PostedOn { get; set; }
        public string UrlSlug { get; set; }
    }
}