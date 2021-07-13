using CAFEMENU.Entities.Concrate.Categories;
using CAFEMENU.Entities.Concrate.Products;
using CAFEMENU.Entities.Concrate.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.DataAccess.Concrate.Contexts
{
    public class CafeMenuContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=cafe_menu_dotnetFive;Username=postgres;Password=Postgre.2897; Port = 5432");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
