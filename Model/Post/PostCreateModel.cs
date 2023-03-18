using System.ComponentModel.DataAnnotations;

namespace Model.Post
{
    public class PostCreateModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public string TagsName { get; set; }

        [Required]
        public bool Published { get; set; }
    }
}