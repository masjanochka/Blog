using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Frontend.Models
{
    public class Registration
    {
        [Required(ErrorMessage = @"First name requred")]
        [Display(Name = @"First name: ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = @"Last Name requred")]
        [Display(Name = @"LastName: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = @"Login required")]
        [Display(Name = @"UserName: ")]
        public string Username { get; set; }

        [Required(ErrorMessage = @"Password requred")]
        [Display(Name = @"Password: ")]
        public string Password { get; set; }

        [Required(ErrorMessage = @"Confirmation required.")]
        [Compare("Password")]
        [Display(Name = @"Confirm password: ")]
        public string Confirmation { get; set; }
    }
}