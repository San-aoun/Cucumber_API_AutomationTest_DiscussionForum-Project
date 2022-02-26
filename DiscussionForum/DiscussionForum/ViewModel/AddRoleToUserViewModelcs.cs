using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiscussionForum.ViewModel
{
    public class AddRoleToUserViewModelcs
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
    }
}
