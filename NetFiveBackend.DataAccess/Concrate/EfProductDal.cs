using CAFEMENU.Core.DataAccess;
using CAFEMENU.Core.DataAccess.EntityFramework;
using CAFEMENU.DataAccess.Abstract;
using CAFEMENU.DataAccess.Concrate.Contexts;
using CAFEMENU.Entities.Concrate.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.DataAccess.Concrate
{
    public class EfProductDal: EfEntityRepositoryBase<Product, CafeMenuContext>, IProductDal
    {
    }
}
