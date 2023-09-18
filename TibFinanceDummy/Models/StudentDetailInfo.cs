namespace TibFinanceDummy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentDetailInfos")]
    public partial class StudentDetailInfo
    {
        [Key]
        public int Std_Other_Info_ID { get; set; }

        public int? StudentId { get; set; }

        [StringLength(50)]
        public string Std_Father_Name { get; set; }

        [StringLength(50)]
        public string Std_Mother_Name { get; set; }

        [StringLength(50)]
        public string Std_Phone { get; set; }

        [StringLength(50)]
        public string Std_Gender { get; set; }

        [StringLength(50)]
        public string Std_BloodGroup { get; set; }
    }
}
