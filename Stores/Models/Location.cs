using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class Location
    {
        [Key]
        [Required]
        [StringLength(10)]
        [DisplayName("Location Code")]
        public string LocationCode { get; set; }

        [Required]
        [DisplayName("Location")]
        [StringLength(50)]
        public string LocationName { get; set; }
    }
}
