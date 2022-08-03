using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Stores.Models
{
    public class TransactionType
    {
        [Key]
        [DisplayName("Transactiion Type Id")]
        public int? TransactionTypeId { get; set; }

        [Required]
        [DisplayName("Transaction Type")]
        [StringLength(120, MinimumLength = 12)]
        public string TransactionTypes { get; set; }

    }
}
