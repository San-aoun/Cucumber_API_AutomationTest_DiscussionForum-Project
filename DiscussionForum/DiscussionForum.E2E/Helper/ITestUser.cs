using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscussionForum.E2E.Helper
{
    public interface ITestUser
    {
        string Email { get; }
        string Role { get; }
    }
}
