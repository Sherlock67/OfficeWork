﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibFinance.Shared.ViewModels
{
    public class vmMenu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
