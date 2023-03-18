using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Post
{
    public class PostUpdateModel
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

        public DateTime PostedOn { get; set; }
    }
}