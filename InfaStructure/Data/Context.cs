using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfaStructure.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

      public DbSet<Category> Categories { get; set; }
      public DbSet<Product> Products { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<Order>Orders  { get; set; }
       public DbSet<OrderDetail> OrderDetails { get; set; }
       public DbSet<Image> Images { get; set; }

       

    }
}
