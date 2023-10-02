using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinance.Shared.ViewModels;

namespace TibFinanceBusinessLayer.Helper
{
    public static class SkipOverload
    {
        public static int Skip(vmCmnParameters cmncls)
        {
            int skipnumber = 0;
            if (cmncls.pageNumber > 0)
            {
                skipnumber = ((int)cmncls.pageNumber - 1) * (int)cmncls.pageSize;
            }
            return skipnumber;
        }
    }
}
