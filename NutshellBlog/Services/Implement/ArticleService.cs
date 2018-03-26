using NutshellBlog.Models;
using NutshellBlog.Repositories;
using NutshellBlog.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutshellBlog.Services.Implement
{
    public class ArticleService
        : Service<Article>, IArticleService
    {
        public ArticleService(IArticleRepository repository)
            : base(repository)
        {

        }
    }
}
