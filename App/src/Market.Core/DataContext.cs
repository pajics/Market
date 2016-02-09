using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Market.Core
{
    public class DataContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Product> Products { get; set; }
    }
}
