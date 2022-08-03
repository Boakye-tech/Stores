using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Stores.Models.ViewModels
{
    public class BinCardVM
    {
        public BinCard BinCard { get; set; }
        public BinCardModel BinCardModel { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
        public IEnumerable<SelectListItem> LocationDropDown { get; set; }
        public IEnumerable<SelectListItem> UnitDropDown { get; set; }
    }
}
