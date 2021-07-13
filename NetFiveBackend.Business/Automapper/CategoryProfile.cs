using CAFEMENU.Core.Mapping.Automapper;
using CAFEMENU.DataAccess.Concrate;
using CAFEMENU.Entities.Concrate.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Business.Automapper
{
    public class CategoryProfile: BaseProfile
    {
        public CategoryProfile()
        {
            CreateMap<EfCategoryDal, Category>();
        }
    }
 
}
