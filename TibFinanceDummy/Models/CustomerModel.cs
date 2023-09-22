using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TibFinanceDummy.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}