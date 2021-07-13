using CAFEMENU.Core.DataAccess.EntityFramework;
using CAFEMENU.DataAccess.Abstract;
using CAFEMENU.DataAccess.Concrate.Contexts;
using CAFEMENU.Entities.Concrate.Categories;

namespace CAFEMENU.DataAccess.Concrate
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, CafeMenuContext >, ICategoryDal
    {

    }
}
