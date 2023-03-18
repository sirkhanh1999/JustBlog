namespace Entity.Entity
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}