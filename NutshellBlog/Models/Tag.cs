using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NutshellBlog.Models
{
    public class Tag
        : Entity
    {

        public string Label { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
