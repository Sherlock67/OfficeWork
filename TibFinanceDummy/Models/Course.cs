using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TibFinanceDummy.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseCode { get; set; }  
    }
}