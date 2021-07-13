using CAFEMENU.Core.Mapping.Automapper;
using CAFEMENU.DataAccess.Concrate;
using CAFEMENU.Entities.Concrate.Products;
using CAFEMENU.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Business.Automapper
{
    public class ProductProfile: BaseProfile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
       
}
