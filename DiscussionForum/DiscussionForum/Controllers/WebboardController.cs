using System.Linq;
using System.Threading.Tasks;
using DiscussionForum.Models.db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using DiscussionForum.ViewModel;

namespace DiscussionForum.Controllers
{
    public class WebboardController : Controller
    {
        private readonly DiscussionForumDBContext _db;

        public WebboardController(DiscussionForumDBContext db)
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

        public async Task<IActionResult> Search(string q)
        {
            var ds = _db.Discussions
                .OrderByDescending(d => d.RecordDate)
                .Include(c => c.Category)
                .Where(u => u.IsShow == true)
                .Where(i => i.DiscussionTopic.Contains(q));

            if (ds == null)
            {
                return NotFound();
            }
            return View("index", await ds.ToListAsync());
        }

        public async Task<IActionResult> TopicComment(int id)
        {
            var dc = _db.Discussions
                .Include(c => c.Category)
                .Where(i => i.IsShow == true)
                .FirstOrDefault(k => k.Did == id);

            if (dc == null)
            {
                return NotFound();
            }
            if (id != dc.Did)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var viewcount = dc.ViewCount;
                    viewcount++;

                    dc.ViewCount = viewcount;
                    _db.Update(dc);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    var result = _db.Discussions.Any( d => d.Did == id);
                    if (result==false)
                    {
                        return NotFound();
                    }

                }
            }

            var veiwModel = new TopicCommentVeiwModel()
            {
                Discussion = dc
            };

            ViewData["TopicCommentVeiwModel"] = veiwModel;   

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TopicComment(Comment data)
        {
            if (ModelState.IsValid)
            {
                var cs = await _db.Comments
                    .OrderByDescending(i => i.CommenNo)
                    .Where(c => c.Did == data.Did)
                    .FirstOrDefaultAsync();

                int currentNo;
                if (cs != null)
                {
                    currentNo = cs.CommenNo;
                    currentNo++;
                }
                else
                {
                    currentNo = 1;
                }

                data.CommenNo = currentNo;
                data.ReplyDate = DateTime.Now;  
                data.UserIp = HttpContext.Connection.RemoteIpAddress.ToString();
                data.IsShow = true;
                _db.Add(data);

                var ds = await _db.Discussions.Where(d => d.Did == data.Did).FirstOrDefaultAsync();
                var replycount = ds.ReplyCount;
                replycount++;
                ds.ReplyCount = replycount; 
                _db.Update(ds);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(data);


        }
    }
}
