using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Models
{
    public class BinCard
    {
        [Key]
        [Required]
        [StringLength(10)]
        [DisplayName("Bin Card Number")]
        public string BinCardNumber { get; set; }

        [Required]
        [DisplayName("Item Description")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage ="Please select a valid item")]
        public string ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual Items ItemDescription { get; set; }

        [Required]
        [DisplayName("Location")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Please select a valid location")]
        public string LocationCode { get; set; }
        [ForeignKey("LocationCode")]
        public virtual Location LocationName { get; set; }

        [Required]
        [DisplayName("Maximum Stock Level")]
        [Range(1,99999999, ErrorMessage ="Please the maximum stock level cannot be 0, enter a number greater than 0")]
        public int MaximumStockLevel { get; set; }

        [Required]
        [DisplayName("Minimum Stock Level")]
        [Range(1, 99999999, ErrorMessage = "Please the minimum stock level cannot be 0, enter a number greater than 0")]
        public int MinimumStockLevel { get; set; }

        [Required]
        [DisplayName("Re-order Level")]
        [Range(1, 99999999, ErrorMessage = "Please the re-order level cannot be 0, enter a number greater than 0")]
        public int ReOrderLevel { get; set; }

        [Required]
        [DisplayName("Stock Figures Unit")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9]", ErrorMessage = "Please select a valid unit of measure")]
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public virtual MeasuringUnit UnitName { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        public float UnitPrice { get; set; }

     }
}
