using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stores.Models;

namespace Stores.ViewModels
{
    public class BinCardTransactionsVM
    {
        public BinCardModel BinCardModel { get; set; }
        public BinCardTransactions BinCardTransactionsModel { get; set; }
        public IEnumerable<SelectListItem> TransTypeDropDown { get; set; }
    }
}
