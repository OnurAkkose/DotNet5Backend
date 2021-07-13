using CAFEMENU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IBaseEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
