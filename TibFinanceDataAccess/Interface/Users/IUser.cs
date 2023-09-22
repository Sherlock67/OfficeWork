using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Interface.Base;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Interface.Users
{
    public interface IUser : IBaseRepository<User>
    {
    }
}
