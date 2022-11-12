using Microsoft.EntityFrameworkCore;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistence
{
    public class NTECommerceDbContext : AuditableDbContext
    {
        public NTECommerceDbContext(DbContextOptions<NTECommerceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(c => c.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(c => c.AppliedDiscount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(c => c.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(c => c.StorageType)
                .HasConversion<int>();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
