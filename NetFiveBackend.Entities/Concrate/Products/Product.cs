using CAFEMENU.Core.Entities;
using CAFEMENU.Entities.Concrate.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Entities.Concrate.Products
{
    public class Product: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryId{ get; set; }
       
    }

    
}

