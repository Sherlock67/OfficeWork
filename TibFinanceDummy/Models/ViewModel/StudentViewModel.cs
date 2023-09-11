using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TibFinanceDummy.Models.ViewModel
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public int Roll {  get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Std_Other_Info_ID { get; set; }
        public string Std_Father_Name { get; set; }
        public string Std_Mother_Name { get; set; }
        public string Std_Phone { get; set; }
        public string Std_Gender { get; set; }
        public string Std_BloodGroup { get; set; }
        public int TotalData { get;set; }

    }
}