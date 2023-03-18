using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Comment
{
    public class CommentDetailsModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }

        public Guid PostId { get; set; }
        public string PostTitle { get; set; }
    }
}