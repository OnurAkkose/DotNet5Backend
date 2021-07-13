using CAFEMENU.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Entities.Concrate.Categories
{
    public class Category : IBaseEntity
    {
        public int ParentId { get; set; }
        public int Id { get; set ; }
        public string Name { get; set; }
    }
}
