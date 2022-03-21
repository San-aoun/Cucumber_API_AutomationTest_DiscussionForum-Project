using DiscussionForum.E2E.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.E2E.TestData
{
    public class AdminUser : ITestUser
    {
        public string Email => Username;
        public string Username => "Admin";
        public string Fullname => "Admin Test";
        public string Password => "TTT_ttt123";
        public string Role => "Admin";
    }
    public class StandardUser : ITestUser
    {
        public string Email => Username;
        public string Username => "Member";
        public string Fullname => "Member Test";
        public string Password => "TTT_ttt123";
        public string Role => "Memer";
    }

}
