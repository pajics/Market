using Market.Core.Identity;
using Market.Core.Products;
using Market.Core.Users;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Market.Core.Database
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }
    }
}
