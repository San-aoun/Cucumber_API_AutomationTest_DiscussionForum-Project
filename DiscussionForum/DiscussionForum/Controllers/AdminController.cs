using DiscussionForum.Models;
using DiscussionForum.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscussionForum.Controllers
{
    //[Authorize(Roles= "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModel = new List<UserRolesViewModel>();
            foreach (var item in users)
            {
                var vm = new UserRolesViewModel();
                vm.UserId = item.Id;
                vm.Email = item.Email;
                vm.Username = item.UserName;
                vm.Fullname = item.Fullname;
                vm.Roles = await GetRoleList(item);

                viewModel.Add(vm);
            }
            return View(viewModel);  
        }
        private async Task<List<string>> GetRoleList(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel data)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = data.Email;
                user.Email = data.Email;
                user.Fullname = "";
                user.Address = "";
                user.ImageUrl = "";

                var result = await _userManager.CreateAsync(user, data.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync("Admin"))
                    {
                        var role = new IdentityRole("Admin");
                        var roleresult = await _roleManager.CreateAsync(role);
                    }

                    await _userManager.AddToRoleAsync(user, "Admin");
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View("Index", data);
        }
        public IActionResult AddRoleToUser(string id)
        {
            ApplicationUser user =  _userManager.FindByIdAsync(id).Result;
            var viewModel = new AddRoleToUserViewModelcs
            {
                UserId = user.Id,
                Email = user.Email,
                Roles = GetAllRole()

            };

            return View(viewModel);
        }
        private SelectList GetAllRole()
        {
            return new SelectList(_roleManager.Roles.OrderBy(u => u.Name));
        }
    }
}
