using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DiscussionForum.Models;
using DiscussionForum.Models.db;
using DiscussionForum.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DiscussionForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly DiscussionForumDBContext _db;

        public HomeController(DiscussionForumDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var viewmodel = new MainIndexViewModel()
            {
                CategoriesLists = _db.Categories,
                DiscussionsLists = _db.Discussions.OrderByDescending(r => r.RecordDate).Take(10).Include(c => c.Category).Where(i => i.IsShow == true)
            };
            return View(viewmodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
