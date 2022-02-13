using System.Linq;
using System.Threading.Tasks;
using DiscussionForum.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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

        public IActionResult Create()
        {
            ViewData["CategoriesLists"] = new SelectList(_db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discussion data)
        {
            if (ModelState.IsValid)
            {
                data.RecordDate = DateTime.Now;
                data.ViewCount = 1;
                data.ReplyCount = 0;
                data.UserIp = HttpContext.Connection.RemoteIpAddress.ToString();
                data.IsShow = true;

                _db.Discussions.Add(data);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriesLists"] = new SelectList(_db.Categories, "CategoryId", "CategoryName");

            return View(data);
        }
        public async Task<IActionResult> DiscussionByCategoryId(int id)
        {
            var ds = _db.Discussions
                .OrderByDescending(d => d.RecordDate)
                .Include(c => c.Category)
                .Where(u => u.IsShow == true)
                .Where(i => i.CategoryId == id);

            if (ds == null)
            {
                return NotFound();
            }
            return View("index",await ds.ToListAsync());
        }
    }
}
