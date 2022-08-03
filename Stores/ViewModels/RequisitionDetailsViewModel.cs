using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Stores.ViewModels
{
    public class RequisitionDetailsViewModel
    {
        
        public string RequisitionNumber { get; set; }

        [DisplayName("Bin Card Number")]
        public string BinCardNumber { get; set; }

        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }

        [DisplayName("Measure Unit")]
        public string MeasureUnit { get; set; }

        [DisplayName("Quantity Requested")]
        public int QuantityRequested { get; set; }

        [DisplayName("Quantity Approved")]
        public int QuantityApproved { get; set; }

        [DisplayName("Quantity Issued")]
        public int QuantityIssued { get; set; }

        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }

        public decimal Value { get; set; }
    }

    
}
