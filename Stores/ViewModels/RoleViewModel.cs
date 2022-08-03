using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.ViewModels
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {
            Users = new List<string>();
        }

        [DisplayName("Role Id")]
        public string Id { get; set; }

        [Required(ErrorMessage ="Please role name is required")]
        [Display(Name="Role")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
        
    }
}
