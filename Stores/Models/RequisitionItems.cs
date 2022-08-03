using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Models
{
    public class RequisitionItems
    {
        [Key]
        [Required]
        [StringLength(6)]
        [DisplayName("Requisition Number")]
        public string RequisitionNumber { get; set; }

        [Key]
        [Required]
        [DisplayName("Bin Card Number")]
        [StringLength(10)]
        public string BinCardNumber { get; set; }

        [Required]
        [DisplayName("Quantity Requested")]
        [Range(1, 99999999, ErrorMessage = "Please the quantity requested cannot be 0, enter a number greater than 0")]
        public int QuantityRequested { get; set; }

        [Required]
        [DisplayName("Quantity Issued")]
        [Range(1, 99999999, ErrorMessage = "Please the quantity issued cannot be 0, enter a number greater than 0")]
        public int QuantityIssued { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        [Range(1, 99999999, ErrorMessage = "Please the unit price cannot be 0, enter a number greater than 0")]
        public decimal UnitPrice { get; set; }

        public decimal Value { get; set; }

        public string Remarks { get; set; }
        
    }
}



