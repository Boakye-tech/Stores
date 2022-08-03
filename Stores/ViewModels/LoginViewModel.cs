using System;
using System.ComponentModel.DataAnnotations;

namespace Stores.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
