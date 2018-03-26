using Microsoft.AspNetCore.Mvc;
using NutshellBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutshellBlog.Infrastructure
{
    public class BaseController : Controller
    {
        protected IArticleService _articleService;
    }
}
