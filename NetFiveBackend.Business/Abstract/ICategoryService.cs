using CAFEMENU.Core.Utilities.Results;
using CAFEMENU.Entities.Concrate.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Business.Concrete.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();
    } 
    
}
