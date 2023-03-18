using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Category
{
    public class CategoryDetailsModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
    }
}