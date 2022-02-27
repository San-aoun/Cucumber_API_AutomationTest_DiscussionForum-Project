using DiscussionForum.Models;
using DiscussionForum.Models.db;
using DiscussionForum.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace DiscussionForum.Controllers
{
    [Authorize(Roles = "Member,Admin")]
    public class HomeController : Controller
    {
        private readonly discussionForumDBContext _db;

        public HomeController(discussionForumDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var viewmodel = new MainIndexViewModel()
            {
                CategoriesLists = _db.Categories,
                DiscussionsLists = _db.Discussions
                .OrderByDescending(r => r.RecordDate)
                .Take(10).Include(c => c.Category)
                .Where(i => i.IsShow == true)
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
