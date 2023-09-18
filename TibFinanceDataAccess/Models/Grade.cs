namespace TibFinanceDataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grade")]
    public partial class Grade
    {
        public int GradeId { get; set; }

        [StringLength(50)]
        public string GradeName { get; set; }

        public int? StudentId { get; set; }
    }
}
