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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users").Property(p => p.Id);//.HasColumnName("UserId"); //http://stackoverflow.com/questions/19460386/how-can-i-change-the-table-names-when-using-visual-studio-2013-aspnet-identity
            builder.Entity<Product>().ToTable("Products").Property(p => p.Id);
        }
    }
}
