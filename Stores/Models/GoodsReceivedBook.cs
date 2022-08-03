using System;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class GoodsReceivedBook
    {
        [Key]
        [Required]
        [StringLength(10)]
        public string GRBNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string OrderNumber { get; set; }
        public string SupplierCode { get; set; }
        public string WayBillNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string ItemCode { get; set; }
        public int QuantityReceived { get; set; }
        public string BinCardNumber { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Value { get; set; }
        public string StoreKeeper { get; set; }
    }
}
