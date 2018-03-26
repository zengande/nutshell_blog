using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NutshellBlog.Data;
using NutshellBlog.Infrastructure;
using NutshellBlog.Models;

namespace NutshellBlog.Repositories.Implement
{
    public class ArticleRepository
        : Repository<Article>, IArticleRepository
    {
        public ArticleRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
