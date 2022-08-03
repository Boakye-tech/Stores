using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Models
{
    public class RequisitionNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequisitionNoteId { get; set; }

        [Required]
        [StringLength(6)]
        [DisplayName("Requisition Number")]
        public string RequisitionNumber { get; set; }

        [Required]
        [DisplayName("Requisition Date")]
        [DataType(DataType.Date)]
        public DateTime RequisitionDate { get; set; }

        [Required]
        [DisplayName("Location")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Please select a valid location")]
        public string LocationCode { get; set; }
        [ForeignKey("LocationCode")]
        public virtual Location LocationName { get; set; }

        [Required]
        [DisplayName("Department")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Please select a valid department")]
        public int DepartmentCode { get; set; }
        [ForeignKey("DepartmentCode")]
        public virtual Department DepartmentName { get; set; }

        [Required]
        [DisplayName("Full Name")]
        [StringLength(6)]
        public string StaffIdentificationNumber { get; set; }

        //[Required]
        [DisplayName("Bin Card Number")]
        [StringLength(10)]
        public string BinCardNumber { get; set; }

        [Required]
        [DisplayName("Item Description")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Please select a valid item")]
        public string ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual Items ItemDescription { get; set; }

        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        [DisplayName("Unit of Measure")]
        public virtual MeasuringUnit UnitName { get; set; }
        
        [Required]
        [DisplayName("Quantity Requested")]
        [Range(1, 99999999, ErrorMessage = "Please the quantity requested cannot be 0, enter a number greater than 0")]
        public int QuantityRequested { get; set; }

        [DisplayName("Quantity Approved")]
        public int QuantityApproved { get; set; }

        [DisplayName("Quantity Issued")]
        public int QuantityIssued { get; set; }

        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        public decimal Value { get; set; }
        public string  Remarks { get; set; }

        public string FHODAuthorization { get; set; }
        public DateTime FHODAuthorizationDate { get; set; }

        [StringLength(6)]
        public string IssuedBy { get; set; }
        public DateTime IssuedDate { get; set; }

        [StringLength(20)]
        public string Status { get; set; }
    }


}
