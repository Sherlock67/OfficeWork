﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Interface.Base;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Interface.UserPermissions
{
    public interface IUserPermission : IBaseRepository<UserPermission>
    {
        bool CreateList(List<UserPermission> entity);
    }
}
