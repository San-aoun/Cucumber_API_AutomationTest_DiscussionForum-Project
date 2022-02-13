using DiscussionForum.Models.db;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class WebboardController : Controller
    {
        private readonly discussionForumDBContext _db;

        public WebboardController(discussionForumDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
