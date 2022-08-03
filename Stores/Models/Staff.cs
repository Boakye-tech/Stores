using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Models
{
    public class Staff
    {
        [Key]
        [Required]
        [StringLength(10)]
        [DisplayName("Staff Identification Number")]
        public string StaffIdentificationNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Middlename { get; set; }

        public int DepartmentCode { get; set; }
        [ForeignKey("DepartmentCode")]
        public virtual Department DepartmentName  { get; set; }
        
    }
}
