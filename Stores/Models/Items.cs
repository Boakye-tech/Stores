using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class Items
    {
        [Key]
        [Required]
        [StringLength(10)]
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
    }
}
