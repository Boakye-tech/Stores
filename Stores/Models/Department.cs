using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class Department
    {
        [Key]
        [DisplayName("Department Code")]
        public int DepartmentCode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
    }
}
