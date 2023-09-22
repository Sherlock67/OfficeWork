using System.ComponentModel.DataAnnotations;

namespace TibFinanceDataAccess.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get;set;}
        public string ModuleName { get;set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get;set;}
       // public int MenuId { get; set; }

    }
}
