using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Stores.Models
{
    public class BinCardTransactions
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        [StringLength(10)]
        public string BinCardNumber { get; set; }
        public DateTime TransactionDate { get; set; }

        [Required]
        [DisplayName("Transaction Type")]
        public int TransactionTypeId { get; set; }
        [ForeignKey("TransactionTypeId")]
        public virtual TransactionType TransactionType { get; set; }

        [DisplayName("Receipt Note Number")]
        public string GRBNoteNumber { get; set; }
        [DisplayName("Quantity Received")]
        public int QuantityReceived { get; set; }
        [DisplayName("Issued Note Number")]
        public string RequistionNumber { get; set; }
        [DisplayName("Quantity Issued")]
        public int QuantityIssued { get; set; }
        public int Balance { get; set; }
        public string Remarks { get; set; }
        public string Who { get; set; }
    }
}
