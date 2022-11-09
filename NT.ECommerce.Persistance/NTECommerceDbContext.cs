using Microsoft.EntityFrameworkCore;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistance
{
    public class NTECommerceDbContext : AuditableDbContext
    {
        public NTECommerceDbContext(DbContextOptions<NTECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
