using System;
using System.ComponentModel.DataAnnotations;


namespace Stores.Models
{
    public class MeasuringUnit
    {
        [Key]
        public int? UnitId { get; set; }

        [Required]
        [StringLength(15)]
        public string UnitName { get; set; }
    }
}
