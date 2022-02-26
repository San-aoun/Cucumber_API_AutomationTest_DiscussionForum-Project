using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.ViewModel
{
    public class LoginVeiwModel
    {
        [Required(ErrorMessage = "Please, Indentify the Email")]
        [Display(Name = "E-mail: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, Create Password")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
