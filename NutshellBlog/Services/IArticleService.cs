using NutshellBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutshellBlog.Services
{
    public interface IArticleService
        : IService<Article>
    {
    }
}
