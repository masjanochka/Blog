using System.ComponentModel.DataAnnotations;

namespace Blog.WebUI.Frontend.Models
{
    public class User
    {
        [Required(ErrorMessage = @"Login required")]
        [Display(Name = @"UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = @"Password requred")]
        [Display(Name = @"Password")]
        public string Password { get; set; }
    }
}