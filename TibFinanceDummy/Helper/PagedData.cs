﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TibFinanceDummy.Helper
{
    public class PagedData<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }
        public int Count { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}