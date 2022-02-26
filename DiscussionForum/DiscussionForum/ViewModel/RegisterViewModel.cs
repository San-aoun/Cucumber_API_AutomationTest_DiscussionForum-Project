using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please, Indentify the Email")]
        [Display(Name ="E-mail: ")]
        public string Email { get; set; } 
        
        [Required(ErrorMessage ="Please, Create Password")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, Confirm Password")]
        [Display(Name = "Confirm password: ")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Wrong password")]
        public string PasswordAgain { get; set; }


    }
}
