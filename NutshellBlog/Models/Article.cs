using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NutshellBlog.Models
{
    public class Article
        : Entity
    {
        public Article()
        {
            LastEditTime = DateTimeOffset.Now.DateTime;
        }
        public string Identity { get; set; }

        public DateTime? PublishTime { get; set; }

        public DateTime? LastEditTime { get; set; }

        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string Description { get; set; }

        public int? ArchivesId { get; set; }
        [ForeignKey("ArchivesId")]
        public virtual Archives Archives { get; set; }
        public virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
