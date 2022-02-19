using DiscussionForum.Models;
using DiscussionForum.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiscussionForum.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, 
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel data)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Email = data.Email;
                user.UserName = data.Email;

                var result = await _userManager.CreateAsync(user, data.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("Member"))
                    {
                        var role = new IdentityRole("Member");
                        var roleresults = await _roleManager.CreateAsync(role);

                        await _userManager.AddToRoleAsync(user, "Member"); 
                    }                                 
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }
                    return RedirectToAction(nameof(Index));
                }            
                else
                {
                    foreach ( var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }       
            }
            return View();
        }
    }
}
