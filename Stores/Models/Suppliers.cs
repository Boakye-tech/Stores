using System;
using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class Suppliers
    {
        [Key]
        [StringLength(10)]
        public string SupplierCode { get; set;}

        public string FullName { get; set; }
        public string PostalAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string MobileNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string EmailAddress { get; set; }
        public string TinNumber { get; set; }
        public string GPSLocation { get; set; }
        public string ContactPerson { get; set; }
    }
}
