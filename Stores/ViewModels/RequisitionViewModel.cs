using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Stores.ViewModels
{
    public class RequisitionViewModel
    {
        [DisplayName("Requisition Number")]
        public string RequisitionNumber { get; set; }

        [DisplayName("Requisition Date")]
        [DataType(DataType.Date)]
        public DateTime RequisitionDate { get; set; }

        public string Location { get; set; }

        public string Department { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        public string Status { get; set; }

        public List<RequisitionDetailsViewModel> requisitionDetails { get; set; }
    }
    
    class RequisitionListViewModelComparer : IEqualityComparer<RequisitionViewModel>
    {
        public bool Equals(RequisitionViewModel x, RequisitionViewModel y)
        {
            if (x.RequisitionNumber == y.RequisitionNumber && x.RequisitionDate == y.RequisitionDate)
                return true;

            return false;
        }

        public int GetHashCode(RequisitionViewModel obj)
        {
            return obj.RequisitionNumber.GetHashCode();
        }

       
    }
}
