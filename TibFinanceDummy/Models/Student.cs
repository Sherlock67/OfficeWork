namespace TibFinanceDummy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int StudentId { get; set; }

        [StringLength(50)]
        public string StudentName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int? Roll { get; set; }

        public int? DepartmentId { get; set; }

        [StringLength(255)]
        public string ImagePath { get; set; }
    }
}
