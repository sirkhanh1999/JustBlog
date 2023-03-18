using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tag
{
    public class TagDetailsModel
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        public string UrlSlug { get; set; }

        public string Decription { get; set; }
        public int Count { get; set; }
    }
}