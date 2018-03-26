using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NutshellBlog.Infrastructure;
using NutshellBlog.Services;
using NutshellBlog.ViewModels;

namespace NutshellBlog.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult Index()
        {
            _articleService.Add(new Models.Article { Title = "测试", Content = "测试" });
            _articleService.SaveEntitiesAsync();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
