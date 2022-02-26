using DiscussionForum.Models;
using DiscussionForum.Models.db;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DiscussionForum.Controllers
{
    [Authorize(Roles ="Member,Admin")]
    public class MemberController : Controller
    {
        public discussionForumDBContext _discussionForumDBContext { get; }

        private readonly UserManager<ApplicationUser> _userManager;

        public MemberController(discussionForumDBContext discussionForumDBContext, 
            UserManager<ApplicationUser> userManager)
        {
            _discussionForumDBContext = discussionForumDBContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

                if (user == null)
                { 
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Index","Account");
            }
            
        }
        public IActionResult Edit(string id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser data, IFormFile files)
        {
            if (id != data.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var userStore = new UserStore<ApplicationUser>(_discussionForumDBContext);
                var userId = _userManager.GetUserId(HttpContext.User);
                ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

                if (user != null)
                {
                    if (files != null)
                    {
                        if (files.Length > 0)
                        {
                            var fileName = Path.GetFileName(files.FileName);
                            var fileExt = Path.GetExtension(fileName);

                            var tempName = Guid.NewGuid().ToString();
                            var newFileName = string.Concat(tempName, fileExt);
                            var filePath = new PhysicalFileProvider(
                                Path.Combine(
                                    Directory.GetCurrentDirectory(), "wwwroot", "images")).Root + $@"\{newFileName}";

                            using (FileStream fs = System.IO.File.Create(filePath))
                            {
                                files.CopyTo(fs);
                                fs.Flush();
                            }

                            user.ImageUrl = newFileName.Trim();
                        }

                    }
                    user.Fullname = data.Fullname;
                    user.Email = data.Email;
                    user.PhoneNumber = data.PhoneNumber;
                    user.BirthDate = data.BirthDate;
                    user.Address = data.Address;

                }
                var result = await _userManager.UpdateAsync(user);
                var ctx = userStore.Context;
                await ctx.SaveChangesAsync();

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Member");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
          
            return View(data);
        }

    }
}
