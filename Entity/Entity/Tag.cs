namespace Entity.Entity
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }

        public string Decription { get; set; }
        public int Count { get; set; }
        public IList<PostTagMap> PostTagMaps { get; set; }
    }
}