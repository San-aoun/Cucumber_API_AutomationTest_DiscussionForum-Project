using System.Linq;
using System.Threading.Tasks;
using DiscussionForum.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Controllers
{
    public class WebboardController : Controller
    {
        private readonly discussionForumDBContext _db;

        public WebboardController(discussionForumDBContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var ds = _db.Discussions.OrderByDescending(d => d.RecordDate).Include(c => c.Category).Where(u => u.IsShow == true);

            if (ds == null)
            {
                return NotFound();
            }
            return View(await ds.ToListAsync());
        }
    }
}
