using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Stores.Models.ViewModels

{
    public class ItemsVM
    {
        public Items Items { get; set; }
        public IEnumerable<SelectListItem> TypeDropDown { get; set; }
    }
}
