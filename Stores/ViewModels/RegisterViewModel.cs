using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Stores.ViewModels
{
    public class RegisterViewModel
    {
       
        public IEnumerable<SelectListItem> DepartmentDropDown { get; set; }
        [DisplayName("Department")]
        public int DepartmentCode { get; set; }
        
        public IEnumerable<SelectListItem> StaffDropDown { get; set; }
        [DisplayName("Fullname")]
        public string StaffIdentificationNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
