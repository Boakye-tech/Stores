using System;
namespace Stores.ViewModels
{

    public class StaffViewModel
    {
        public string StaffIdentificationNumber { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Surname { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
