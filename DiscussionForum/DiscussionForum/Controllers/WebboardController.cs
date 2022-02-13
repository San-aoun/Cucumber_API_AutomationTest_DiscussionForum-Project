using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class WebboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
