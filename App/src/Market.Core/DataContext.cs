using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Market.Core
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
