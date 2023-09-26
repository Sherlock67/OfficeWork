using System;
using System.ComponentModel.DataAnnotations;

namespace TibFinanceDataAccess.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; } 
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int ModuleId { get; set; }
    }
}
