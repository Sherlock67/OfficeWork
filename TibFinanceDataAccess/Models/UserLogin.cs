using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibFinanceDataAccess.Models
{
    public class UserLogin
    {
        [Key]
        public int LoginID { get; set; }
        public int UserId { get; set; }
       
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
