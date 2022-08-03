using System;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class LocalPurchaseOrder
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string LPONumber { get; set; }
        public string Source { get; set; }
        public string Purpose { get; set; }
        public string SupplierCode { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public string ItemCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public string LocationCode { get; set; }
        public DateTime LPOReleaseDate { get; set; }
        public DateTime DateSignedByMD { get; set; }
        public DateTime DateSignedByProcurement{ get; set; }
        public string ProcurementOfficerCode { get; set; }
        public string DeliveryPeriod { get; set; }
        public string PaymentTerms { get; set; }
        public string Who { get; set; }
    }
}
