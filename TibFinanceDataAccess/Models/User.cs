using System.ComponentModel.DataAnnotations;

namespace TibFinanceDataAccess.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleId { get; set; }
    }
}
