using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TibFinanceDummy.Models.ViewModel
{
    public class GradeViewModel
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set;}
        public int TotalData { get; set; }  
    }
}