using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stores.Models;

namespace Stores.ViewModels
{
    public class RequisitionNoteVM
    {
        public RequisitionNote RequisitionNote { get; set; }

        public IEnumerable<SelectListItem> DepartmentDropDown { get; set; }
        public IEnumerable<SelectListItem> StaffDropDown { get; set; }
        public IEnumerable<SelectListItem> ItemDropDown { get; set; }
        public IEnumerable<SelectListItem> LocationDropDown { get; set; }
    }

}
