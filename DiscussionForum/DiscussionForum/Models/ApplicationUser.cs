using Microsoft.AspNetCore.Identity;
using System;

namespace DiscussionForum.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Fullname { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
