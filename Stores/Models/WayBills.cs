using System;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class WayBills
    {
        [Key]
        [StringLength(10)]
        public string WayBillNumber { get; set; }

        public DateTime WayBillDate { get; set; }
        public string SupplierCode { get; set; }
        public string VehicleNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string DriversName { get; set; }
        public string MobileNumber{ get; set; }
        public int Quantity { get; set; }
        public string ItemCode { get; set; }
        public string Remarks { get; set; }
        public string DispatchedBy { get; set; }
        public DateTime DispatchDate { get; set; }
        public string ReceivedBy { get; set; }
        public DateTime DateReceived { get; set; }
        public string Whom { get; set; }
    }
}
