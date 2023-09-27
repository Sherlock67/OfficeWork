using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TibFinanceDataAccess.Interface.Base
{
    public interface IBaseRepository<T>
    {
         T Create(T entity);
        void Update(T entity);

         IEnumerable<T> GetAll();
         T GetById(int? Id);
         void Delete(T entity);
    }
}
