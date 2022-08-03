using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Stores.Models
{
    [Keyless]
    public class BinCardModel
    {
        [DisplayName("Bin Card Number")]
        public string BinCardNumber { get; set; }
        [DisplayName(" ")]
        public string ItemCode { get; set; }
        [DisplayName("Item Description")]
        public string ItemDescription  { get; set; }
        [DisplayName("Location")]
        public string LocationName { get; set; }
        [DisplayName("Maximum Stock Level")]
        public int MaximumStockLevel { get; set; }
        [DisplayName("Minimum Stock Level")]
        public int MinimumStockLevel { get; set; }
        [DisplayName("Re-order Level")]
        public int ReOrderLevel { get; set; }
        [DisplayName(" ")]
        public int? UnitId { get; set; }
        [DisplayName("Stock Figures Unit")]
        public string UnitName { get; set; }
        [DisplayName("Unit Price")]
        public float UnitPrice { get; set; }
    }
}
